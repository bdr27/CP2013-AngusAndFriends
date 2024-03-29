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
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl, IControl
    {
        public HomeControl()
        {
            InitializeComponent();
            var str = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(@str);
            wbMain.Navigate(new Uri(str + @"Images/gmaps.html", UriKind.Absolute));
        }

        public void Reset()
        {
            // does not have anything to reset
        }
    }
}
