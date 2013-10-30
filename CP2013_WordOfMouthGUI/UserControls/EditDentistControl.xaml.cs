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
    /// Interaction logic for EditDentistControl.xaml
    /// </summary>
    public partial class EditDentistControl : UserControl, IControl
    {
        public EditDentistControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Cmbox_DentistName.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayOne.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayTwo.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayThree.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFour.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayFive.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySix.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DaySeven.SelectedIndex = -1;
            UsrCntrl_TimeSlots.LstView_DayOne.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayTwo.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayThree.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayFour.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DayFive.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DaySix.Items.Clear();
            UsrCntrl_TimeSlots.LstView_DaySeven.Items.Clear();
        }

        public void AddBtn_UpdateHandler(RoutedEventHandler handler)
        {
            Btn_Update.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        private List<ListView> GetControlList()
        {
            var listofcontrols = new List<ListView>();

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

            return listofcontrols;
        }

        public void SetDentists(List<Dentist> dentists)
        {
            if (dentists == null)
                return;

            Cmbox_DentistName.Items.Clear();

            foreach (var dentist in dentists)
            {
                Cmbox_DentistName.Items.Add(dentist);
            }

            Cmbox_DentistName.SelectedIndex = 0;
        }

        public void AddCmbox_DentistNameHandler(SelectionChangedEventHandler handler)
        {
            Cmbox_DentistName.SelectionChanged += handler;
        }

        public void SetTimeSlots(List<TimeSlot> times)
        {
            // set all times to empty
            var listofviews = GetControlList();
            for (int i = 0; i < 7; ++i)
            {
            }
        }
    }
}
