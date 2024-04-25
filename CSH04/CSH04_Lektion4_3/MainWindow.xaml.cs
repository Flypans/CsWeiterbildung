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

namespace CSH04_Lektion4_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mouse_Event(object sender, MouseButtonEventArgs e)
        {
            listBox.Items.Add("B: " + sender.ToString());
            //e.Handled = true;
        }

        private void PreviewMouseEvent(object sender, MouseButtonEventArgs e)
        {
            listBox.Items.Add("T: " + sender.ToString());
            //e.Handled = true;
        }
    }
}
