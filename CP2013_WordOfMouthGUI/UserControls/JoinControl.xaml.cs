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
    /// Interaction logic for JoinControl.xaml
    /// </summary>
    public partial class JoinControl : UserControl, IControl
    {
        public JoinControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            TxtBox_Email.Text = "";
            TxtBox_EmailConfirm.Text = "";
            TxtBox_FirstName.Text = "";
            TxtBox_LastName.Text = "";
            TxtBox_Mobile.Text = "";
            PassBox_Password.Password = "";
            PassBox_PasswordConfirm.Password = "";
            Lbl_EmailMatch.Content = "";
            Lbl_PasswordMatch.Content = "";
            Btn_Join.IsEnabled = false;
        }

        public void AddBtn_JoinHandler(RoutedEventHandler handler)
        {
            Btn_Join.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        private void TextField_TextChanged(object sender, TextChangedEventArgs e)
        {
            Btn_Join.IsEnabled = CheckValidility();
        }

        private bool CheckValidility()
        {
            var ln = TxtBox_LastName;
            var isValid = true;

            if (!CheckValidTextBox(TxtBox_Email, TxtBox_EmailConfirm, TxtBox_FirstName, TxtBox_LastName, TxtBox_Mobile) ||
                !CheckValidSameEmail(TxtBox_Email, TxtBox_EmailConfirm) || !CheckValidSamePassword(PassBox_Password, PassBox_PasswordConfirm)
                || !CheckValidMobileNumber(TxtBox_Mobile.Text) || !CheckValidEmail(TxtBox_Email.Text))
            {
                isValid = false;
            }

            return isValid;
        }

        private bool CheckValidEmail(string email)
        {
            return Regex.Match(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$").Success;
        }

        private bool CheckValidMobileNumber(string mobile)
        {
            return Regex.Match(mobile, @"^04([0-9]{8})$").Success;
        }

        private bool CheckValidSameEmail(TextBox email, TextBox confirm)
        {
            return email.Text.Equals(confirm.Text);
        }

        private bool CheckValidSamePassword(PasswordBox pass, PasswordBox confirm)
        {
            return pass != null && confirm != null && pass.Password != null && confirm.Password != null && pass.Password.Equals(confirm.Password) && pass.Password.Length > 7;
        }

        private bool CheckValidTextBox(params TextBox[] tbs)
        {
            foreach (var tb in tbs)
            {
                if (tb == null || tb.Text == null || tb.Text.Trim().Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            Btn_Join.IsEnabled = CheckValidility();
            if (PassBox_Password.Password.Length > 7)
            {
                if (PassBox_Password.Password.Equals(PassBox_PasswordConfirm.Password))
                {
                    Lbl_PasswordMatch.Foreground = Brushes.Green;
                    Lbl_PasswordMatch.Content = "Passwords Match";
                }
                else
                {
                    Lbl_PasswordMatch.Foreground = Brushes.Red;
                    Lbl_PasswordMatch.Content = "Passwords Do Not Match";
                }
            }
            else
            {
                Lbl_PasswordMatch.Foreground = Brushes.Red;
                Lbl_PasswordMatch.Content = "Minimum of 8 characters";
            }
        }

        private void EmailsChanged(object sender, TextChangedEventArgs e)
        {
            Btn_Join.IsEnabled = CheckValidility();
            if (CheckValidEmail(TxtBox_Email.Text))
            {
                if (TxtBox_Email.Text.Equals(TxtBox_EmailConfirm.Text))
                {
                    Lbl_EmailMatch.Foreground = Brushes.Green;
                    Lbl_EmailMatch.Content = "Emails Match";
                }
                else
                {
                    Lbl_EmailMatch.Foreground = Brushes.Red;
                    Lbl_EmailMatch.Content = "Emails Do Not Match";
                }
            }
            else
            {
                Lbl_EmailMatch.Foreground = Brushes.Red;
                Lbl_EmailMatch.Content = "Email Not Valid";
            }
        }

        public SignUp GetSignUp()
        {
            return new SignUp(TxtBox_Email.Text, PassBox_Password.Password,TxtBox_EmailConfirm.Text, 
                PassBox_PasswordConfirm.Password, TxtBox_Mobile.Text, TxtBox_FirstName.Text, TxtBox_LastName.Text);
        }
    }
}
