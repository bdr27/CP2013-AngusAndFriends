﻿using CP2013_WordOfMouthGUI.Interfaces;
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
    /// Interaction logic for RemoveAppointmentTypeControl.xaml
    /// </summary>
    public partial class RemoveAppointmentTypeControl : UserControl, IControl
    {
        public RemoveAppointmentTypeControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Cmbox_TypeName.SelectedIndex = -1;
        }

        public void AddBtn_RemoveHandler(RoutedEventHandler handler)
        {
            Btn_Remove.Click += handler;
        }

        public void AddBtn_CancelHandler(RoutedEventHandler handler)
        {
            Btn_Cancel.Click += handler;
        }

        internal void SetDentists(List<CP2013_WordOfMouth.DTO.Dentist> dentists)
        {
            throw new NotImplementedException();
        }
    }
}
