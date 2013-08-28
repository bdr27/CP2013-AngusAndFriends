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

namespace CP2013_Assignment_One_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class MainUI : UserControl
    {
        public MainUI()
        {
            InitializeComponent();
        }

        public void AddAboutHandler(RoutedEventHandler handler)
        {
            btnAbout.Click += handler;
        }

        public void AddAdminHandler(RoutedEventHandler handler)
        {
            btnAdmin.Click += handler;
        }

        public void AddContactHandler(RoutedEventHandler handler)
        {
            btnContact.Click += handler;
        }

        public void AddUserHandler(RoutedEventHandler handler)
        {
            btnUser.Click += handler;
        }
    }
}
