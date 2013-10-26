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
        }

        public void AddBtn_JoinHandler(RoutedEventHandler handler)
        {
            Btn_Join.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }
    }
}
