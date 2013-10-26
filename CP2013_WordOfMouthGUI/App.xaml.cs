using CP2013_WordOfMouth.Controllers;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        private IUserController controller;

        public App()
            : base()
        {
            window = new MainWindow();
            controller = new UserController();

            AssignHandlers();
            window.ResetWindow();
            ModifyPage(controller.GetSystemState());

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
            if (controller.SetSystemState(action))
            {
                ModifyPage(controller.GetSystemState());
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
            CompleteAction(UserActions.JOIN_CLICK);
        }

        private void HandleBtn_LogInClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.LOGIN_CLICK);
        }

        private void HandleBtn_CancelClick(object sender, RoutedEventArgs e)
        {
            CompleteAction(UserActions.CANCEL_CLICK);
        }
    }
}
