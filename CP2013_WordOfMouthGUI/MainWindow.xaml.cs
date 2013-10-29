using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouthGUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP2013_WordOfMouthGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ResetWindow()
        {
            //Btn_Home.IsEnabled = true;
            //Btn_LogInOut.IsEnabled = true;
            //Btn_Appointments.IsEnabled = false;
            //Btn_Admin.IsEnabled = false;

            DisablePage(UsrCntrl_Home);
            DisablePage(UsrCntrl_Join);
            DisablePage(UsrCntrl_LogIn);
            DisablePage(UsrCntrl_MyApps);
            DisablePage(UsrCntrl_Admin);
            DisablePage(UsrCntrl_AddAppType);
            DisablePage(UsrCntrl_AddDentist);
            DisablePage(UsrCntrl_EditDentist);
            DisablePage(UsrCntrl_NewApp);
            DisablePage(UsrCntrl_RemoveAppType);
            DisablePage(UsrCntrl_RemoveDentist);
        }

        public void AddBtn_HomeHandler(RoutedEventHandler handler)
        {
            Btn_Home.Click += handler;
        }

        public void AddBtn_LogInOutHandler(RoutedEventHandler handler)
        {
            Btn_LogInOut.Click += handler;
        }

        public void SetPage(UserControl control)
        {
            control.IsEnabled = true;
            control.Visibility = Visibility.Visible;
            ((IControl) control).Reset();
        }

        private void DisablePage(UserControl control)
        {
            control.IsEnabled = false;
            control.Visibility = Visibility.Hidden;
        }

        public Login GetLogin()
        {
            return new Login(UsrCntrl_LogIn.TxtBox_Email.Text, UsrCntrl_LogIn.PassBox_Password.Password);
        }

        public void AddBtn_AppointmentsHandler(RoutedEventHandler handler)
        {
            Btn_Appointments.Click += handler;
        }

        public void AddBtn_AdminHandler(RoutedEventHandler handler)
        {
            Btn_Admin.Click += handler;
        }
    }
}
