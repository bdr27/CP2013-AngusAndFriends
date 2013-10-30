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
using System.Windows.Controls;

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
            window.AddBtn_AppointmentsHandler(HandleBtn_AppointmentsClick);
            window.AddBtn_AdminHandler(HandleBtn_AdminClick);

            window.UsrCntrl_LogIn.AddBtn_LoginHandler(HandleBtn_LogInClick);
            window.UsrCntrl_LogIn.AddBtn_JoinHandler(HandleBtn_JoinClick);

            window.UsrCntrl_Join.AddBtn_JoinHandler(HandleBtn_JoinClick);
            window.UsrCntrl_Join.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_AddAppType.AddBtn_CancelHandler(HandleBtn_CancelClick);
            window.UsrCntrl_AddAppType.AddBtn_CreateHandler(HandleBtn_CreateClick);

            window.UsrCntrl_AddDentist.AddBtn_CreateHandler(HandleBtn_CreateClick);
            window.UsrCntrl_AddDentist.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_Admin.AddBtn_NewDentistHandler(HandleBtn_NewDentistClick);
            window.UsrCntrl_Admin.AddBtn_EditDentistHandler(HandleBtn_EditDentistClick);
            window.UsrCntrl_Admin.AddBtn_RemoveDentistHandler(HandleBtn_RemoveDentistClick);
            window.UsrCntrl_Admin.AddBtn_NewAppTypeHandler(HandleBtn_NewAppTypeClick);
            window.UsrCntrl_Admin.AddBtn_RemoveAppTypeHandler(HandleBtn_RemoveAppTypeClick);

            window.UsrCntrl_EditDentist.AddBtn_UpdateHandler(HandleBtn_UpdateClick);
            window.UsrCntrl_EditDentist.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_MyApps.AddBtn_CreateNewHandler(HandleBtn_CreateClick);
            window.UsrCntrl_MyApps.AddBtn_CancelHandler(HandleBtn_RemoveClick);

            window.UsrCntrl_NewApp.AddBtn_CreateHandler(HandleBtn_CreateClick);
            window.UsrCntrl_NewApp.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_RemoveAppType.AddBtn_RemoveHandler(HandleBtn_RemoveClick);
            window.UsrCntrl_RemoveAppType.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_RemoveDentist.AddBtn_RemoveHandler(HandleBtn_RemoveClick);
            window.UsrCntrl_RemoveDentist.AddBtn_CancelHandler(HandleBtn_CancelClick);

            window.UsrCntrl_NewApp.AddCmbox_DentistFilterChangedHandler(HandleCmbox_DentistFilterChange);
            window.UsrCntrl_EditDentist.AddCmbox_DentistNameHandler(HandleCmbox_DentistNameChange);
        }

        private void HandleBtn_RemoveClick(object sender, RoutedEventArgs e)
        {
            if (stateMachine.GetSystemState() == StateOfSystem.APPOINTMENTS_PAGE)
            {
                var appSel = window.UsrCntrl_MyApps.GetSelectedAppID();
                if (appSel != -1)
                {
                    stateMachine.SetSystemState(UserActions.REMOVE_CLICK);
                    var thread = new RemoveAppointmentThread(5000, appSel);
                    thread.eventHandler += HandleRequestComplete;
                    thread.Start();
                }
            }
            else if (stateMachine.GetSystemState() == StateOfSystem.REMOVE_APPOINT_TYPE_PAGE)
            {
                if (window.UsrCntrl_RemoveAppType.Cmbox_TypeName.SelectedItem is CP2013_WordOfMouth.DTO.AppointmentType)
                {
                    var type = window.UsrCntrl_RemoveAppType.Cmbox_TypeName.SelectedItem as CP2013_WordOfMouth.DTO.AppointmentType;
                    stateMachine.SetSystemState(UserActions.REMOVE_CLICK);
                    var thread = new RemoveAppointmentTypeThread(5000, type.GetID());
                    thread.eventHandler += HandleRequestComplete;
                    thread.Start();
                }
            }
            else if (stateMachine.GetSystemState() == StateOfSystem.REMOVE_DENTIST_PAGE)
            {
                if (window.UsrCntrl_RemoveDentist.Cmbox_DentistName.SelectedItem is Dentist)
                {
                    var dentist = window.UsrCntrl_RemoveDentist.Cmbox_DentistName.SelectedItem as Dentist;
                    stateMachine.SetSystemState(UserActions.REMOVE_CLICK);
                    var thread = new RemoveDentistThread(5000, dentist.GetID());
                    thread.eventHandler += HandleRequestComplete;
                    thread.Start();
                }
            }
            else
            {
                CompleteAction(UserActions.REMOVE_CLICK);
            }
        }

        private void HandleBtn_UpdateClick(object sender, RoutedEventArgs e)
        {
            if (stateMachine.GetSystemState() == StateOfSystem.EDIT_DENTIST_PAGE)
            {
                var information = window.UsrCntrl_EditDentist.GetSelectedAppointmentsList();
                if (information != null)
                {
                    stateMachine.SetSystemState(UserActions.UPDATE_CLICK);

                    var thread = new EditDentistTimeSlotThread(5000, information);
                    thread.eventHandler += HandleRequestComplete;
                    thread.Start();
                }
            }
            else
            {
                CompleteAction(UserActions.UPDATE_CLICK);
            }
        }

        private void HandleBtn_NewDentistClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.ADD_DEN_CLICK);
        }

        private void HandleBtn_EditDentistClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.EDIT_DEN_CLICK);
        }

        private void HandleBtn_RemoveDentistClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.REMOVE_DEN_CLICK);
        }

        private void HandleBtn_NewAppTypeClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.ADD_APP_TYPE_CLICK);
        }

        private void HandleBtn_RemoveAppTypeClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.REMOVE_APP_TYPE_CLICK);
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
                        var thread = new GetUserAppointments(5000, sessionKey.GetSessionID());
                        thread.eventHandler += HandleAppointmentsMyAppsUpdate;
                        thread.Start();
                    } break;
                case StateOfSystem.VERIFY_JOIN:
                    {
                        window.SetPage(window.UsrCntrl_Join);
                    } break;
                case StateOfSystem.ADD_DENTIST_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_AddDentist);
                    } break;
                case StateOfSystem.EDIT_DENTIST_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_EditDentist);
                        var thread = new GetDentistsThread(5000, "");
                        thread.eventHandler += HandleGetDentistsEditDenUpdate;
                        thread.Start();
                    } break;
                case StateOfSystem.REMOVE_DENTIST_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_RemoveDentist);
                        var thread = new GetDentistsThread(5000, "");
                        thread.eventHandler += HandleGetDentistsRemoveDenUpdate;
                        thread.Start();
                    } break;
                case StateOfSystem.ADD_APPOINT_TYPE_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_AddAppType);
                    } break;
                case StateOfSystem.REMOVE_APPOINT_TYPE_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_RemoveAppType);
                        var thread = new GetAppointmentTypesThread(5000, 0);
                        thread.eventHandler += HandleGetAllAppTypesRemAppUpdate;
                        thread.Start();
                    } break;
                case StateOfSystem.CREATE_APPOINT_PAGE:
                    {
                        window.SetPage(window.UsrCntrl_NewApp);
                        var thread = new GetDentistsThread(5000, "");
                        thread.eventHandler += HandleGetAllDentistsNewAppUpdate;
                        thread.Start();
                        var threadTypes = new GetAppointmentTypesThread(5000, 0);
                        threadTypes.eventHandler += HandleGetAllAppTypesNewAppUpdate;
                        threadTypes.Start();
                    } break;
                case StateOfSystem.VERIFY_REMOVE_APPOINT_TYPE:
                    {
                        window.SetPage(window.UsrCntrl_RemoveAppType);
                    } break;
                case StateOfSystem.VERIFY_REMOVE_DENTIST:
                    {
                        window.SetPage(window.UsrCntrl_RemoveDentist);
                    } break;
            }
        }

        private void HandleGetAllAppTypesRemAppUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.APPOINTMENT_TYPES)
                {
                    var types = e.Infomation as List<CP2013_WordOfMouth.DTO.AppointmentType>;
                    window.UsrCntrl_RemoveAppType.SetAppTypes(types);
                }
            });
        }

        private void HandleGetDentistsRemoveDenUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.DENTISTS)
                {
                    var dentists = e.Infomation as List<Dentist>;
                    window.UsrCntrl_RemoveDentist.SetDentists(dentists);
                }
            });
        }

        private void HandleGetDentistsEditDenUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.DENTISTS)
                {
                    var dentists = e.Infomation as List<Dentist>;
                    window.UsrCntrl_EditDentist.SetDentists(dentists);
                }
            });
        }

        private void HandleGetDentistTimesEditDenUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.TIMESLOTS)
                {
                    var times = e.Infomation as List<CP2013_WordOfMouth.DTO.TimeSlot>;
                    window.UsrCntrl_EditDentist.SetTimeSlots(times);
                }
            });
        }

        private void HandleCmbox_DentistNameChange(object sender, SelectionChangedEventArgs e)
        {
            if (window.UsrCntrl_EditDentist.Cmbox_DentistName.SelectedItem is Dentist)
            {
                var dentist = window.UsrCntrl_EditDentist.Cmbox_DentistName.SelectedItem as Dentist;
                var thread = new NewAppTimeSlotsThread(5000, dentist.GetID());
                thread.eventHandler += HandleGetDentistTimesEditDenUpdate;
                thread.Start();
            }
        }

        private void HandleGetAllAppTypesNewAppUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.APPOINTMENT_TYPES)
                {
                    var types = e.Infomation as List<CP2013_WordOfMouth.DTO.AppointmentType>;
                    window.UsrCntrl_NewApp.SetAppTypes(types);
                }
            });
        }

        private void HandleGetAllDentistsNewAppUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.DENTISTS)
                {
                    var dentists = e.Infomation as List<Dentist>;
                    window.UsrCntrl_NewApp.SetDentists(dentists);
                }
            });
        }

        private void HandleAppointmentsMyAppsUpdate(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.APPOINTMENTS)
                {
                    var app = e.Infomation as List<Appointment>;
                    window.UsrCntrl_MyApps.SetAppointments(app);
                }
            });
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
                stateMachine.SetSystemState(UserActions.JOIN_CLICK);
                //I sign up here right? YES stop asking me that.
                var signup = window.UsrCntrl_Join.GetSignUp();
                var thread = new JoinThread(5000, signup);
                thread.eventHandler += HandleRequestComplete;
                thread.Start();
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
                if (e.LoggedIn)
                {
                    stateMachine.SetLoginStatus(e.SessionID);
                    sessionKey = e.SessionID;
                    LaunchThread();
                }

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
            if (stateMachine.GetSystemState() == StateOfSystem.LOGIN_PAGE)
            {
                stateMachine.SetSystemState(UserActions.LOGIN_CLICK);
                var login = window.UsrCntrl_LogIn.GetLogin();
                var thread = new LoginThread(5000, login);
                thread.eventHandler += HandleRequestComplete;
                thread.Start();
            }
            else
            {
                CompleteAction(UserActions.LOGIN_CLICK);
            }
        }

        private void HandleBtn_CancelClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.CANCEL_CLICK);
        }

        private void HandleBtn_CreateClick(object sender, RoutedEventArgs e)
        {
            if (stateMachine.GetSystemState() == StateOfSystem.CREATE_APPOINT_PAGE)
            {
                var booking = window.UsrCntrl_NewApp.GetBooking(sessionKey.GetSessionID());
                if (booking != null)
                {
                    stateMachine.SetSystemState(UserActions.CREATE_CLICK);
                    var thread = new MakeAppointmentThread(5000, booking);
                    thread.eventHandler += HandleRequestComplete;
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Please select a valid time slot.");
                }
            }
            else
            {
                CompleteAction(UserActions.CREATE_CLICK);
            }
        }

        private void HandleBtn_AppointmentsClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.APPOINTMENTS_CLICK);
        }

        private void HandleBtn_AdminClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.ADMIN_CLICK);
        }

        private void LaunchThread()
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
                    //timeoutTimer.Enabled = true;
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

        private void HandleCmbox_DentistFilterChange(object sender, SelectionChangedEventArgs e)
        {
            if (window.UsrCntrl_NewApp.Cmbox_DentistFilter.SelectedItem != null)
            {
                var dentist = window.UsrCntrl_NewApp.Cmbox_DentistFilter.SelectedItem as Dentist;
                var thread = new NewAppTimeSlotsThread(5000, dentist.GetID());
                thread.eventHandler += HandleGetNewAppTimeSlotsComplete;
                thread.Start();
            }
        }

        private void HandleGetNewAppTimeSlotsComplete(object sender, RequestCompleteArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.RequestType == RequestReturnType.TIMESLOTS)
                {
                    var times = e.Infomation as List<CP2013_WordOfMouth.DTO.TimeSlot>;
                    window.UsrCntrl_NewApp.SetTimeSlots(times);
                }
            });
        }
    }
}
