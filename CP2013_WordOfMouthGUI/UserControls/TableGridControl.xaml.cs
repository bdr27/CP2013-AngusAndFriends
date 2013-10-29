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

namespace CP2013_WordOfMouthGUI
{
    /// <summary>
    /// Interaction logic for TableGridControl.xaml
    /// </summary>
    public partial class TableGridControl : UserControl
    {
        public TableGridControl()
        {
            InitializeComponent();
        }

        public void AddLstOneHandler(SelectionChangedEventHandler handler)
        {
            LstView_DayOne.SelectionChanged += handler;
        }

        public void AddLstTwoHandler(SelectionChangedEventHandler handler)
        {
            LstView_DayTwo.SelectionChanged += handler;
        }

        public void AddLstThreeHandler(SelectionChangedEventHandler handler)
        {
            LstView_DayThree.SelectionChanged += handler;
        }

        public void AddLstFourHandler(SelectionChangedEventHandler handler)
        {
            LstView_DayFour.SelectionChanged += handler;
        }

        public void AddLstFiveHandler(SelectionChangedEventHandler handler)
        {
            LstView_DayFive.SelectionChanged += handler;
        }

        public void AddLstSixHandler(SelectionChangedEventHandler handler)
        {
            LstView_DaySix.SelectionChanged += handler;
        }

        public void AddLstSevenHandler(SelectionChangedEventHandler handler)
        {
            LstView_DaySeven.SelectionChanged += handler;
        }
    }
}
