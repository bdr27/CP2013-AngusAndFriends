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
    /// Interaction logic for AdminPanelControl.xaml
    /// </summary>
    public partial class AdminPanelControl : UserControl, IControl
    {
        public AdminPanelControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            //
        }

        public void AddBtn_NewDentistHandler(RoutedEventHandler handler)
        {
            Btn_NewDentist.Click += handler;
        }

        public void AddBtn_EditDentistHandler(RoutedEventHandler handler)
        {
            Btn_EditDentist.Click += handler;
        }

        public void AddBtn_RemoveDentistHandler(RoutedEventHandler handler)
        {
            Btn_RemoveDentist.Click += handler;
        }

        public void AddBtn_NewAppTypeHandler(RoutedEventHandler handler)
        {
            Btn_NewAppType.Click += handler;
        }

        public void AddBtn_RemoveAppTypeHandler(RoutedEventHandler handler)
        {
            Btn_RemoveAppType.Click += handler;
        }
    }
}
