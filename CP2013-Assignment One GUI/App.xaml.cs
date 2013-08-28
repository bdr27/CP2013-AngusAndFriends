using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;
using CP2013_Assignment_One.MOCK;
using CP2013_Assignment_One_GUI.UserControls;

namespace CP2013_Assignment_One_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow;
        FileHandler fileHandler;

        public App()
            : base()
        {
            fileHandler = new MOCKFileHandler();
            mainWindow = new MainWindow();
            mainWindow.Show();
            WireHandlers();
        }

        private void WireHandlers()
        {
            WireMainUIHandlers();
        }

        #region MainUI
        private void WireMainUIHandlers()
        {
            var mainUI = mainWindow.viewMainUI;
            mainUI.AddAboutHandler(HandleAbout_Click);
            mainUI.AddAdminHandler(HandleAdmin_Click);
            mainUI.AddContactHandler(HandleContact_Click);
            mainUI.AddUserHandler(HandlerUser_Click);
        }

        private void HandlerUser_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowUser();
            Debug.WriteLine("User Click");
        }

        private void HandleContact_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowContact();
            Debug.WriteLine("Contact Click");
        }

        private void HandleAbout_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowAbout();
            Debug.WriteLine("About Click");
        }
        #endregion

        #region AdminUI
        private void HandleAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowAdmin();
            var admin = mainWindow.viewAdminUI;
            WireAdminHandlers(admin);
            LoadDentists(admin);
            Debug.WriteLine("Admin Click");
        }

        private void LoadDentists(AdminUI admin)
        {
            var dentist = fileHandler.GetDentists();
            admin.LoadDentists(dentist, admin.cbDentist);
            admin.LoadDentists(dentist, admin.cbDentistRemove);
        }

        private void WireAdminHandlers(AdminUI admin)
        {
            admin.AddBtnTimeSlotDoneHandler(HandleTimeSlotDone_Click);
            admin.AddBtnAddDentistHandler(HandleAddDentistDone_Click);
            admin.AddBtnRemoveDentistHandler(HandleRemoveDentistDone_Click);
        }

        private void HandleRemoveDentistDone_Click(object sender, RoutedEventArgs e)
        {
            var admin = mainWindow.viewAdminUI;
            var dentistID = admin.GetRemoveDentistID();
            fileHandler.DeleteDentist(dentistID);
            LoadDentists(admin);
        }

        private void HandleAddDentistDone_Click(object sender, RoutedEventArgs e)
        {
            var admin = mainWindow.viewAdminUI;
            var dentistName = admin.GetDentistName();
            fileHandler.AddNewUser(new MOCKUser(dentistName, UserType.DENTIST));
            LoadDentists(admin);
        }

        private void HandleTimeSlotDone_Click(object sender, RoutedEventArgs e)
        {
            var admin = mainWindow.viewAdminUI;
            var day = admin.GetDay();
            var month = admin.GetMonth();
            var year = admin.GetYear();
            var start = admin.GetStart();
            var end = admin.GetEnd();
            var startDate = new DateTime(year, month, day, start, 0, 0);
            var endDate = new DateTime(year, month, day, end, 0, 0);
            var dentistID = admin.GetDentistID();

            fileHandler.AddNewTimeSlot(new MOCKTimeSlot(startDate, endDate, dentistID));
            LoadDentists(admin);
        }
        #endregion
    }
}
