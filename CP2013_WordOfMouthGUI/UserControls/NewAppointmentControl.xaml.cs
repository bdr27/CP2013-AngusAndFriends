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

namespace CP2013_WordOfMouthGUI.UserControls
{
    /// <summary>
    /// Interaction logic for NewAppointmentControl.xaml
    /// </summary>
    public partial class NewAppointmentControl : UserControl, IControl
    {

        public NewAppointmentControl()
        {
            InitializeComponent();
            UsrCntrl_TimeSlots.AddLstOneHandler(HandleLstOneChange);
            UsrCntrl_TimeSlots.AddLstTwoHandler(HandleLstTwoChange);
            UsrCntrl_TimeSlots.AddLstThreeHandler(HandleLstThreeChange);
            UsrCntrl_TimeSlots.AddLstFourHandler(HandleLstFourChange);
            UsrCntrl_TimeSlots.AddLstFiveHandler(HandleLstFiveChange);
            UsrCntrl_TimeSlots.AddLstSixHandler(HandleLstSixChange);
            UsrCntrl_TimeSlots.AddLstSevenHandler(HandleLstSevenChange);
        }

        public void Reset()
        {
            Cmbox_DentistFilter.SelectedIndex = -1;
            Cmbox_AppointmentTypeFilter.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        public void AddBtn_CreateHandler(RoutedEventHandler handler)
        {
            Btn_CreateAppointment.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        public void AddCmbox_DentistFilterChangedHandler(SelectionChangedEventHandler handler)
        {
            Cmbox_DentistFilter.SelectionChanged += handler;
        }

        public void SetDentists(List<Dentist> dentists)
        {
            Cmbox_DentistFilter.Items.Clear();
            foreach (var dentist in dentists)
            {
                Cmbox_DentistFilter.Items.Add(dentist);
            }
            Cmbox_DentistFilter.SelectedIndex = 0;
        }

        private List<ListView> GetControlList(DayOfWeek day)
        {
            var listofcontrols = new List<ListView>();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Sunday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Monday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Tuesday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Wednesday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Thursday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Saturday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Friday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
            }
            else
            {
                UsrCntrl_TimeSlots.Lbl_DayOne.Content = "Sunday";
                UsrCntrl_TimeSlots.Lbl_DayTwo.Content = "Monday";
                UsrCntrl_TimeSlots.Lbl_DayThree.Content = "Tuesday";
                UsrCntrl_TimeSlots.Lbl_DayFour.Content = "Wednesday";
                UsrCntrl_TimeSlots.Lbl_DayFive.Content = "Thursday";
                UsrCntrl_TimeSlots.Lbl_DaySix.Content = "Friday";
                UsrCntrl_TimeSlots.Lbl_DaySeven.Content = "Saturday";
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayOne);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayTwo);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayThree);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFour);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DayFive);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySix);
                listofcontrols.Add(UsrCntrl_TimeSlots.LstView_DaySeven);
            }
            return listofcontrols;
        }

        public void SetTimeSlots(List<TimeSlot> times)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayTwo.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayThree.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayFour.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayFive.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DaySix.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DaySeven.Items.Clear();
            var listofcontrols = GetControlList(DateTime.Now.DayOfWeek);
            
            for (int i = 0; i < 7; ++i)
            {
                var startTime = "8:00";
                var endTime = "18:00";
                foreach (var time in times)
                {
                    if (time.GetDay() == i)
                    {
                        while (!startTime.Equals(time.ToString()))
                        {
                            Console.WriteLine(startTime);
                            listofcontrols.ElementAt(i).Items.Add("-");
                            startTime = GetNextTimeSlot(startTime);
                            if (startTime.Equals(endTime))
                            {
                                break;
                            }
                        }
                        listofcontrols.ElementAt(i).Items.Add(time);
                        startTime = GetNextTimeSlot(startTime);
                        if (startTime.Equals(endTime))
                        {
                            break;
                        }
                    }
                }
                while (!startTime.Equals(endTime))
                {
                    listofcontrols.ElementAt(i).Items.Add("-");
                    startTime = GetNextTimeSlot(startTime);
                    if (startTime.Equals(endTime))
                    {
                        break;
                    }
                }
            }
            /*
            foreach (var time in times)
            {
                
                listofcontrols.ElementAt(time.GetDay()).Items.Add(time);
            }*/
            
        }

        private string GetNextTimeSlot(string time)
        {
            var minutes = 0;
            var hours = 0;
            Int32.TryParse(time.Split(':')[0], out hours);
            Int32.TryParse(time.Split(':')[1], out minutes);

            var mins = minutes + 30;
            var hrs = hours;
            if (mins > 59)
            {
                mins = mins - 60;
                hrs = hours + 1;
            }
            var retTime = hrs + ":";
            if (mins < 10)
                retTime += "0" + mins;
            else
                retTime += mins;

            return retTime;
        }

        private void HandleLstOneChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstTwoChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstThreeChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstFourChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstFiveChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstSixChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
        }

        private void HandleLstSevenChange(object sender, SelectionChangedEventArgs e)
        {
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
        }
    }
}
