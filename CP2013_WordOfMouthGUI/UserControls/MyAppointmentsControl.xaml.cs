using CP2013_WordOfMouthGUI.Interfaces;
using CP2013_WordOfMouth.DTO;
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

namespace CP2013_WordOfMouthGUI.UserControls
{
    /// <summary>
    /// Interaction logic for MyAppointmentsControl.xaml
    /// </summary>
    public partial class MyAppointmentsControl : UserControl, IControl
    {
        List<AppointmentItem> allAppointments;
        List<string> allDentists;

        public MyAppointmentsControl()
        {
            InitializeComponent();
            LstView_AppointmentsList.SelectionMode = SelectionMode.Single;
            allAppointments = null;
            allDentists = null;
        }

        public void Reset()
        {
            LstView_AppointmentsList.SelectedIndex = -1;
        }

        private void HowItWorks()
        {
            LstView_AppointmentsList.Items.Add(new AppointmentItem {AppointmentID = 1, Date = "12/2/12", StartTime = "9:00am", DentistName = "Bob", AppointmentType="Teeth Clean"}); 
        }

        private class AppointmentItem
        {
            public int AppointmentID { get; set; }
            public string Date { get; set; }
            public string StartTime { get; set; }
            public string DentistName { get; set; }
            public string AppointmentType { get; set; }
        }

        internal void SetAppointments(List<Appointment> appointments)
        {
            allAppointments = new List<AppointmentItem>();
            allDentists = new List<string>();

            foreach (var app in appointments)
            {
                var id = app.GetID();
                var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var completeDate = start.AddMilliseconds(app.GetExpectedDate()).ToLocalTime();
                var day = completeDate.Day + "/" + completeDate.Month + "/" + completeDate.Year;
                var time = completeDate.Hour + ":";
                if (completeDate.Minute < 10)
                    time += "0" + completeDate.Minute;
                else
                    time += completeDate.Minute;
                var appItem = new AppointmentItem { AppointmentID = id, Date = day, StartTime = time, DentistName = app.GetTimeSlot().GetDentist().GetName(), AppointmentType = app.GetAppointmentType().GetDescription() };
                allAppointments.Add(appItem);
                if (!allDentists.Contains(appItem.DentistName))
                {
                    allDentists.Add(appItem.DentistName);
                }
            }

            SetUpAppointmentsList();

            Cmbox_DentistFilter.Items.Clear();
            Cmbox_DentistFilter.Items.Add("All");
            foreach (var dentist in allDentists)
            {
                Cmbox_DentistFilter.Items.Add(dentist);
            }
            Cmbox_DentistFilter.SelectedIndex = 0;
        }

        private void SetUpAppointmentsList()
        {
            if (Cmbox_DentistFilter.SelectedItem is string)
            {
                if ((Cmbox_DentistFilter.SelectedItem as string).Equals("All"))
                {
                    LstView_AppointmentsList.Items.Clear();
                    foreach (var app in allAppointments)
                    {
                        LstView_AppointmentsList.Items.Add(app);
                    }
                }
                else if (allAppointments != null && allAppointments.Count > 0)
                {
                    var denName = Cmbox_DentistFilter.SelectedItem as string;
                    LstView_AppointmentsList.Items.Clear();
                    foreach (var app in allAppointments)
                    {
                        if (app.DentistName.Equals(denName))
                        {
                            LstView_AppointmentsList.Items.Add(app);
                        }
                    }
                }
                else
                {
                    Cmbox_DentistFilter.SelectedIndex = 0;
                }
            }
        }

        public void AddBtn_CreateNewHandler(RoutedEventHandler handler)
        {
            Btn_CreateNew.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_CancelAppointments.Click += handler;
        }

        public int GetSelectedAppID()
        {
            if (LstView_AppointmentsList.SelectedItem is AppointmentItem)
            {
                var appSel = LstView_AppointmentsList.SelectedItem as AppointmentItem;
                return appSel.AppointmentID;
            }
            return -1;
        }

        private void Cmbox_DentistFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetUpAppointmentsList();
        }
    }
}
