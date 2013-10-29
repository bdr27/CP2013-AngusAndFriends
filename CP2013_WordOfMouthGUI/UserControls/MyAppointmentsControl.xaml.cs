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
        public MyAppointmentsControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            //
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

        internal void SetAppointments(Appointment app)
        {
            var id = app.GetID();
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var completeDate = start.AddMilliseconds(app.GetExpectedDate());
            var day = completeDate.Day + "/" + completeDate.Month + "/" + completeDate.Year;
            var time = completeDate.Hour + ":" + completeDate.Minute;
            LstView_AppointmentsList.Items.Add(new AppointmentItem { AppointmentID = id, Date = day, StartTime = time, DentistName = app.GetTimeSlot().GetDentist().GetName(), AppointmentType = app.GetAppointmentType().GetType().ToString() });
        }
    }
}
