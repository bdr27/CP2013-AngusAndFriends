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
        int userID;

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
            WireUserUIHandlers();
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
            var selectUser = new SelectUser();
            selectUser.LoadUsers(fileHandler.GetAllUsers());
            selectUser.ShowDialog();
            userID = selectUser.GetUserID();
            LoadBookings();
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
            LoadAdminCombo(admin);
        }

        private void LoadAdminCombo(AdminUI admin)
        {
            var dentist = fileHandler.GetDentists();
            var timeSlots = fileHandler.GetTimeSlots();
            admin.LoadDentists(dentist, admin.cbDentist);
            admin.LoadDentists(dentist, admin.cbDentistRemove);
            admin.LoadTimeSlots(timeSlots, admin.cbTimeSlots);
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
            LoadAdminCombo(admin);
        }

        private void HandleAddDentistDone_Click(object sender, RoutedEventArgs e)
        {
            var admin = mainWindow.viewAdminUI;
            var dentistName = admin.GetDentistName();
            fileHandler.AddNewUser(new MOCKUser(dentistName, UserType.DENTIST));
            LoadAdminCombo(admin);
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
            LoadAdminCombo(admin);
        }
        #endregion

        #region UserUI

        private void WireUserUIHandlers()
        {
            var userUI = mainWindow.viewUserUI;
            userUI.AddBtnRemoveBookingHandler(HandleRemoveButton_Click);
            userUI.AddBtnAddBookingHandler(HandleAddButton_Click);
        }

        private void HandleAddButton_Click(object sender, RoutedEventArgs e)
        {
            var userUI = mainWindow.viewUserUI;
            var timeSlotID = userUI.GetTimeSlotID();
            var bookingType = userUI.GetAppointmentType();
            fileHandler.AddNewBooking(new MOCKBooking(timeSlotID, userID, bookingType));
            LoadBookings();
        }

        private void HandleRemoveButton_Click(object sender, RoutedEventArgs e)
        {
          var userUI = mainWindow.viewUserUI;
          var bookingID = userUI.GetRemoveBookingID();
          fileHandler.DeleteBooking(bookingID);
          LoadBookings();
        }

        private void LoadBookings()
        {
            var userUI = mainWindow.viewUserUI;
            userUI.LoadBookings(fileHandler.GetUserBookings(userID));
            userUI.LoadTimeSlots(fileHandler.GetAvaliableTimeSlots());
        }
        #endregion
    }
}
