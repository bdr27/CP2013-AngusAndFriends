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
    }
}
