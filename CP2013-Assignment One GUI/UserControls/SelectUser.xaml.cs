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
using System.Windows.Shapes;

namespace CP2013_Assignment_One_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for SelectUser.xaml
    /// </summary>
    public partial class SelectUser : Window
    {
        public SelectUser()
        {
            InitializeComponent();
        }


        public void LoadUsers(Dictionary<int, User> dictionary)
        {
            cmbNames.Items.Clear();
            foreach (var user in dictionary.Values)
            {
                cmbNames.Items.Add(user);
            }
            cmbNames.SelectedIndex = 0;
        }

        public int GetUserID()
        {
            var user = (User) cmbNames.SelectedValue;
            return user.GetUserID();
        }

        private void btnPlayerModalDone_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
