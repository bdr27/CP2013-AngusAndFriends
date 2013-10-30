using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouthGUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddAppointmentTypeControl.xaml
    /// </summary>
    public partial class AddAppointmentTypeControl : UserControl, IControl
    {
        public AddAppointmentTypeControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            TxtBox_TypeCost.Text = "";
            TxtBox_TypeName.Text = "";
            Btn_Create.IsEnabled = false;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        public void AddBtn_CreateHandler(RoutedEventHandler handler)
        {
            Btn_Create.Click += handler;
        }

        private void TxtBox_TypeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabled();
        }

        private void TxtBox_TypeCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabled();
        }

        private void CheckEnabled()
        {
            if (TxtBox_TypeName.Text != null && TxtBox_TypeCost.Text != null && !TxtBox_TypeCost.Text.Trim().Equals("") &&
                !TxtBox_TypeName.Text.Trim().Equals("") && (Regex.Match(TxtBox_TypeCost.Text, @"^[0-9]+.[0-9]+$").Success ||
                Regex.Match(TxtBox_TypeCost.Text, @"^[0-9]+$").Success))
            {
                Btn_Create.IsEnabled = true;
            }
            else
            {
                Btn_Create.IsEnabled = false;
            }
        }

        public AppointmentType GetAppointmentType()
        {
            return new AppointmentType(0, TxtBox_TypeName.Text, Double.Parse(TxtBox_TypeCost.Text));
        }
    }
}
