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
    /// Interaction logic for EditDentistDetailsControl.xaml
    /// </summary>
    public partial class EditDentistDetailsControl : UserControl, IControl
    {
        public EditDentistDetailsControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            TxtBox_DentistName.Text = "";
            TxtBox_DentistPhone.Text = "";
            TxtBox_DentistAddress.Text = "";
            Cmbox_DentistFilter.SelectedIndex = -1;
            Btn_Update.IsEnabled = false;
        }

        public void AddBtn_UpdateHandler(RoutedEventHandler handler)
        {
            Btn_Update.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        public void SetDentists(List<Dentist> dentists)
        {
            if (dentists == null)
                return;

            Cmbox_DentistFilter.Items.Clear();

            foreach (var dentist in dentists)
            {
                Cmbox_DentistFilter.Items.Add(dentist);
            }

            Cmbox_DentistFilter.SelectedIndex = 0;
        }

        private void TxtBox_DentistName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void TxtBox_DentistAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void TxtBox_DentistPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void Cmbox_DentistFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void CheckEnabledState()
        {
            if (CheckEmpty(TxtBox_DentistAddress.Text, TxtBox_DentistName.Text, TxtBox_DentistPhone.Text) &&
                Regex.Match(TxtBox_DentistPhone.Text, @"^04([0-9]{8})$").Success &&
                Regex.Match(TxtBox_DentistAddress.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$").Success &&
                Cmbox_DentistFilter.SelectedItem is Dentist)
            {
                Btn_Update.IsEnabled = true;
            }
            else
            {
                Btn_Update.IsEnabled = false;
            }
        }

        private bool CheckEmpty(params string[] strs)
        {
            foreach (var str in strs)
            {
                if (str == null || str.Trim().Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        public Dentist GetDentist()
        {
            if (Cmbox_DentistFilter.SelectedItem is Dentist) {
                var dentist = Cmbox_DentistFilter.SelectedItem as Dentist;
                return new Dentist(dentist.GetID(), TxtBox_DentistName.Text, TxtBox_DentistAddress.Text, TxtBox_DentistPhone.Text);
            }
            return null;
        }
    }
}
