using CP2013_WordOfMouth.Controllers;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.Interface;
using CP2013_WordOfMouth.JSON;
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
                        window.Btn_LogInOut.Content = "Log In";
                        window.SetPage(window.UsrCntrl_Home);
                    } break;
                case StateOfSystem.LOGIN_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_LogIn);
                    } break;
                case StateOfSystem.JOIN_PAGE:
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
        }

        private void HandleBtn_JoinClick(object sender, RoutedEventArgs e)
        {
            if (!isVolatile && stateMachine.GetSystemState() == StateOfSystem.JOIN_PAGE)
            {
                CompleteAction(UserActions.JOIN_CLICK);
                isVolatile = true;
                //I sign up here right? YES stop asking me that.
                var signup = window.UsrCntrl_Join.GetSignUp();
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
                }
            }
            else
            {
                CompleteAction(UserActions.JOIN_CLICK);
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
            CompleteAction(UserActions.LOGIN_CLICK);
            if (!isVolatile && stateMachine.GetSystemState() == StateOfSystem.LOGIN_PAGE)
            {
                // make thread
                isVolatile = true;
                var thread = new Thread(new ThreadStart(loginMethod));
                thread.Start();
                // start timer
            }
        }

        private void loginMethod()
        {
            var i = 5;
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("What?");
                i -= 1;
                if (i == 0)
                {
                    break;
                }
            }
            isVolatile = false;
        }

        private void HandleBtn_CancelClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.CANCEL_CLICK);
        }
    }
}
