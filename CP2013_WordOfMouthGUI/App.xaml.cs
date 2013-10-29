using CP2013_WordOfMouth.Controllers;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.Interface;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.Threads;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CP2013_WordOfMouthGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow window;
        private IStateMachine stateMachine;
        private Session sessionKey = null;
        private Thread sessionThread;
        private System.Timers.Timer timeoutTimer;

        private bool isVolatile;

        public App()
            : base()
        {
            window = new MainWindow();
            stateMachine = new StateMachine();

            isVolatile = false;

            AssignHandlers();
            window.ResetWindow();
            ModifyPage(stateMachine.GetSystemState());

            window.Show();
        }

        private void AssignHandlers()
        {
            window.AddBtn_HomeHandler(HandleBtn_HomeClick);
            window.AddBtn_LogInOutHandler(HandleBtn_LogInOutClick);

            window.UsrCntrl_LogIn.AddBtn_LoginHandler(HandleBtn_LogInClick);
            window.UsrCntrl_LogIn.AddBtn_JoinHandler(HandleBtn_JoinClick);

            window.UsrCntrl_Join.AddBtn_JoinHandler(HandleBtn_JoinClick);
            window.UsrCntrl_Join.AddBtn_CancelHandler(HandleBtn_CancelClick);
        }

        private void ModifyPage(StateOfSystem systemState)
        {
            window.ResetWindow();
            switch (systemState)
            {
                case StateOfSystem.HOME_PAGE_NLI:
                    {
                        window.SetPage(window.UsrCntrl_Home);
                        window.Btn_LogInOut.Content = "Log In";
                        window.Btn_Admin.IsEnabled = false;
                        window.Btn_Appointments.IsEnabled = false;
                    } break;
                case StateOfSystem.LOGIN_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_LogIn);
                    } break;
                case StateOfSystem.JOIN_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_Join);
                    } break;
                case StateOfSystem.HOME_PAGE_ADMIN:
                    {
                        window.SetPage(window.UsrCntrl_Home);
                    } break;
                case StateOfSystem.HOME_PAGE_USER:
                    {
                        window.SetPage(window.UsrCntrl_Home);
                    } break;
                case StateOfSystem.ADMIN_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_Admin);
                        window.Btn_LogInOut.Content = "Log Out";
                        window.Btn_Admin.IsEnabled = true;
                    } break;
                case StateOfSystem.APPOINTMENTS_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_MyApps);
                        window.Btn_LogInOut.Content = "Log Out";
                        window.Btn_Appointments.IsEnabled = true;
                    } break;
                case StateOfSystem.VERIFY_JOIN:
                    {
                        window.SetPage(window.UsrCntrl_Join);
                    } break;
            }
        }

        private void CompleteAction(UserActions action)
        {
            if (!isVolatile && stateMachine.SetSystemState(action))
            {
                ModifyPage(stateMachine.GetSystemState());
            }
        }

        private void HandleBtn_HomeClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.HOME_CLICK);
        }

        private void HandleBtn_LogInOutClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.LOGIN_LOGOUT_CLICK);
            if (stateMachine.GetLoginStatus() == LoginStatus.LOGGED_OUT && sessionKey != null)
            {
                sessionKey = null;
                MessageBox.Show("You have been logged out.");
            }
        }



        private void HandleBtn_JoinClick(object sender, RoutedEventArgs e)
        {
            if (!isVolatile && stateMachine.GetSystemState() == StateOfSystem.JOIN_PAGE)
            {
                //CompleteAction(UserActions.JOIN_CLICK);
                stateMachine.SetSystemState(UserActions.JOIN_CLICK);
                //I sign up here right? YES stop asking me that.
                var signup = window.UsrCntrl_Join.GetSignUp();
                var thread = new JoinThread(5000, signup);
                thread.eventHandler += HandleRequestComplete;
                thread.Start();
                /*
                var response = Response(new JsonSignUp(), new HttpPostSignUp(), signup);
                isVolatile = false;
                if (response.Equals(""))
                {
                    stateMachine.SetSystemState(UserActions.SUCCESS);
                }
                else
                {
                    stateMachine.SetSystemState(UserActions.FAILURE);
                }

                ModifyPage(stateMachine.GetSystemState());

                if (response.Equals(""))
                {
                    MessageBox.Show("You have successfully signed up!");
                }
                else
                {
                    MessageBox.Show(response);
                }*/
            }
            else
            {
                CompleteAction(UserActions.JOIN_CLICK);
            }
        }

        private void HandleRequestComplete(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                stateMachine.SetSystemState(e.Action);
                if (e.RefreshUI)
                {
                    ModifyPage(stateMachine.GetSystemState());
                }
            });

            if (e.DisplayResponse)
            {
                MessageBox.Show(e.Response);
            }
        }

        //This will be the thread
        private string Response(TemplateJson tj, IRequestResponse irr, object o)
        {
            var json = tj.GetJson(o);
            irr.SendRequest(json);
            return irr.GetResponse();
        }

        private void HandleBtn_LogInClick(object sender, RoutedEventArgs e)
        {
            if (!isVolatile && stateMachine.GetSystemState() == StateOfSystem.LOGIN_PAGE)
            {
                CompleteAction(UserActions.LOGIN_CLICK);
                isVolatile = true;
                var login = window.UsrCntrl_LogIn.GetLogin();
                var response = Response(new JsonLogin(), new HttpPostLogin(), login);
                isVolatile = false;
                var sessionJson = new JsonSession();
                try
                {
                    sessionKey = sessionJson.GetObject(response) as Session;
                    stateMachine.SetLoginStatus(sessionKey);
                    stateMachine.SetSystemState(UserActions.SUCCESS);
                    LauchThread();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    sessionKey = null;
                    stateMachine.SetLoginStatus(sessionKey);
                    stateMachine.SetSystemState(UserActions.FAILURE);
                    MessageBox.Show(response);
                }
                ModifyPage(stateMachine.GetSystemState());
            }
            else
            {
                CompleteAction(UserActions.LOGIN_CLICK);
            }
        }

        private void LauchThread()
        {
            sessionThread = new Thread(SessionThread_Run);
            sessionThread.IsBackground = true;            
            sessionThread.Start();            
        }

        private void SessionThread_Run()
        {
            while (true)
            {
                if (sessionKey != null)
                {
                    timeoutTimer = new System.Timers.Timer(5000);
                    timeoutTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimeoutTimer_Tick);
                    timeoutTimer.Enabled = true;
                    var response = Response(new JsonSession(), new HttpPostSession(), sessionKey).ToLower();
                    if (response.Equals("ok"))
                    {
                        timeoutTimer.Enabled = false;
                    }
                    Thread.Sleep(10000);
                }
                else
                {
                    break;
                }
                
            }
        }

        private void TimeoutTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            //I am a time :P
            sessionThread.Abort();
            sessionKey = null;
            timeoutTimer.Enabled = false;
            MessageBox.Show("You have been logged out.");
            stateMachine.SetLoginStatus(sessionKey);
            stateMachine.SetSystemState(UserActions.HOME_CLICK);
            Dispatcher.Invoke(() =>
            {
                ModifyPage(stateMachine.GetSystemState());
            });
        }

        private void HandleBtn_CancelClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.CANCEL_CLICK);
        }
    }
}
