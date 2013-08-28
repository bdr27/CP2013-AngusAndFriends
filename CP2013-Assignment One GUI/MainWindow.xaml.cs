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

namespace CP2013_Assignment_One_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowHome();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            ShowHome();
        }

        public void ShowHome()
        {
            viewMainUI.Visibility = Visibility.Visible;
            viewAboutUI.Visibility = Visibility.Hidden;
            viewAdminUI.Visibility = Visibility.Hidden;
            viewContactUI.Visibility = Visibility.Hidden;
            viewUserUI.Visibility = Visibility.Hidden;
        }

        public void ShowAbout()
        {
            viewMainUI.Visibility = Visibility.Hidden;
            viewAboutUI.Visibility = Visibility.Visible;
            viewAdminUI.Visibility = Visibility.Hidden;
            viewContactUI.Visibility = Visibility.Hidden;
            viewUserUI.Visibility = Visibility.Hidden;
        }

        public void ShowAdmin()
        {
            viewMainUI.Visibility = Visibility.Hidden;
            viewAboutUI.Visibility = Visibility.Hidden;
            viewAdminUI.Visibility = Visibility.Visible;
            viewContactUI.Visibility = Visibility.Hidden;
            viewUserUI.Visibility = Visibility.Hidden;
        }

        public void ShowContact()
        {
            viewMainUI.Visibility = Visibility.Hidden;
            viewAboutUI.Visibility = Visibility.Hidden;
            viewAdminUI.Visibility = Visibility.Hidden;
            viewContactUI.Visibility = Visibility.Visible;
            viewUserUI.Visibility = Visibility.Hidden;
        }

        public void ShowUser()
        {
            viewMainUI.Visibility = Visibility.Hidden;
            viewAboutUI.Visibility = Visibility.Hidden;
            viewAdminUI.Visibility = Visibility.Hidden;
            viewContactUI.Visibility = Visibility.Hidden;
            viewUserUI.Visibility = Visibility.Visible;
        }
    }
}
