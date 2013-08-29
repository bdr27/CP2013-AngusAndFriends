using CP2013_Assignment_One.Interface;
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
using CP2013_Assignment_One.Enum;

namespace CP2013_Assignment_One_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserUI.xaml
    /// </summary>
    public partial class UserUI : UserControl
    {
        public UserUI()
        {
            InitializeComponent();
            LoadBookingTypes();
        }
        private void LoadBookingTypes()
        {
            cbBookingType.Items.Add(AppointmentType.GENERAL);
            cbBookingType.Items.Add(AppointmentType.TEETH_CLEAN);
            cbBookingType.SelectedIndex = 0;
        }

        public AppointmentType GetAppointmentType()
        {
            return (AppointmentType) cbBookingType.SelectedValue;
        }

        public void LoadBookings(Dictionary<int, Booking> dictionary)
        {
            lvBookingTimes.Items.Clear();
            cbRemoveTime.Items.Clear();
            foreach (var booking in dictionary.Values)
            {
                cbRemoveTime.Items.Add(booking);
                lvBookingTimes.Items.Add(booking);
            }
            cbRemoveTime.SelectedIndex = 0;
        }
        public void LoadTimeSlots(Dictionary<int, TimeSlot> dictionary)
        {
            cbAddTime.Items.Clear();
            foreach (var timeSlot in dictionary.Values)
            {
                cbAddTime.Items.Add(timeSlot);
            }
            cbAddTime.SelectedIndex = 0;
        }

        public int GetRemoveBookingID()
        {
            var bookingID = -1;
            var booking = (Booking) cbRemoveTime.SelectedValue;
            if (booking != null)
            {
                bookingID = booking.GetBookingID();
            }
            return bookingID;
        }

        public int GetTimeSlotID()
        {
            var timeSlot = (TimeSlot) cbAddTime.SelectedValue;
            return timeSlot.GetTimeSlotID();
        }

        public void AddBtnRemoveBookingHandler(RoutedEventHandler handler)
        {
            btnRemoveTime.Click += handler;
        }

        public void AddBtnAddBookingHandler(RoutedEventHandler handler)
        {
            btnAddTime.Click += handler;
        }

        public void LoadTimeSlotsLV(Dictionary<int, TimeSlot> timeSlots)
        {
            lvBookingTimes.Items.Clear();
            foreach (var booking in timeSlots.Values)
            {
                lvBookingTimes.Items.Add(booking);
            }
        }
    }
}
