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
    /// Interaction logic for CreateDentistControl.xaml
    /// </summary>
    public partial class CreateDentistControl : UserControl, IControl
    {
        public CreateDentistControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Btn_Create.IsEnabled = false;
            TxtBox_DentistName.Text = "";
            TxtBox_DentistAddress.Text = "";
            TxtBox_DentistPhone.Text = "";
        }

        public void AddBtn_CreateHandler(RoutedEventHandler handler)
        {
            Btn_Create.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        private void CheckEnabledState()
        {
            if (CheckEmpty(TxtBox_DentistAddress.Text, TxtBox_DentistName.Text, TxtBox_DentistPhone.Text) &&
                Regex.Match(TxtBox_DentistPhone.Text, @"^04([0-9]{8})$").Success &&
                Regex.Match(TxtBox_DentistAddress.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$").Success)
            {
                Btn_Create.IsEnabled = true;
            }
            else
            {
                Btn_Create.IsEnabled = false;
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

        private void TxtBox_DentistName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void TxtBox_DentistPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }

        private void TxtBox_DentistAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledState();
        }
    }
}
