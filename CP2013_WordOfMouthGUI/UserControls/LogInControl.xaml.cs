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
    /// Interaction logic for LogInControl.xaml
    /// </summary>
    public partial class LogInControl : UserControl, IControl
    {
        public LogInControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            TxtBox_Email.Text = "";
            PassBox_Password.Password = "";
        }

        public void AddBtn_LoginHandler(RoutedEventHandler handler)
        {
            Btn_LogIn.Click += handler;
        }

        public void AddBtn_JoinHandler(RoutedEventHandler handler)
        {
            Btn_Join.Click += handler;
        }

        public Login GetLogin()
        {
            return new Login(TxtBox_Email.Text, PassBox_Password.Password);
        }
    }
}
