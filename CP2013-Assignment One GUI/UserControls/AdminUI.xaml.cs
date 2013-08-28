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
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for AdminUI.xaml
    /// </summary>
    public partial class AdminUI : UserControl
    {
        public AdminUI()
        {
            InitializeComponent();
        }

        public int GetDay()
        {
            return GetInt(tbDay.Text);
        }

        public int GetMonth()
        {
            return GetInt(tbMonth.Text);
        }

        public int GetYear()
        {
            return GetInt(tbYear.Text);
        }

        public int GetStart()
        {
            return GetInt(tbStartTime.Text);
        }

        public int GetEnd()
        {
            return GetInt(tbEndTime.Text);
        }

        private int GetInt(string s)
        {
            return Int32.Parse(s);
        }

        public void LoadDentists(Dictionary<int, User> dentists, ComboBox cb)
        {
            cb.Items.Clear();
            foreach (var den in dentists.Values)
            {
                cb.Items.Add(den);
            }
            cb.SelectedIndex = 1;
        }

        public int GetDentistID()
        {
           var test = (User) cbDentist.SelectedItem;
           return test.GetUserID();
        }

        public int GetRemoveDentistID()
        {
            var test = (User)cbDentistRemove.SelectedItem;
            return test.GetUserID();
        }

        public void AddBtnTimeSlotDoneHandler(RoutedEventHandler handler)
        {
            btnTimeSlotDone.Click += handler;
        }

        public void AddBtnAddDentistHandler(RoutedEventHandler handler)
        {
            btnAddDentistDone.Click += handler;
        }

        public void AddBtnRemoveDentistHandler(RoutedEventHandler handler)
        {
            btnRemoveDentistDone.Click += handler;
        }

        public string GetDentistName()
        {
            return tbDentistName.Text;
        }

        public void LoadTimeSlots(Dictionary<int, TimeSlot> timeSlots, ComboBox cb)
        {
            cb.Items.Clear();
            foreach (var timeSlot in timeSlots.Values)
            {
                cb.Items.Add(timeSlot);
            }
            cb.SelectedIndex = 1;
       }
    }
}
