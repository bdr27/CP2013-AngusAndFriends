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
    /// Interaction logic for RemoveDentistControl.xaml
    /// </summary>
    public partial class RemoveDentistControl : UserControl, IControl
    {
        public RemoveDentistControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Cmbox_DentistName.SelectedIndex = -1;
            LstView_AppointmentsList.Items.Clear();
        }

        public void AddBtn_RemoveHandler(RoutedEventHandler handler)
        {
            Btn_RemoveDentist.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        public void SetDentists(List<Dentist> dentists)
        {
            if (dentists == null)
                return;

            Cmbox_DentistName.Items.Clear();
            foreach (var dentist in dentists)
            {
                Cmbox_DentistName.Items.Add(dentist);
            }

            Cmbox_DentistName.SelectedIndex = 0;
        }
    }
}
