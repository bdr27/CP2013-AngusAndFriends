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
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        public void AddBtn_CreateHandler(RoutedEventHandler handler)
        {
            Btn_Create.Click += handler;
        }
    }
}
