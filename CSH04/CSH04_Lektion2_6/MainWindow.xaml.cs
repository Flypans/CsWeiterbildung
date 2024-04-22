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

namespace CSH04_Lektion2_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(toggleButton.IsChecked == true)
            {
                toggleButton.Content = "ToggleButton Aktiv";
            }
            else
            {
                toggleButton.Content = "ToggleButton Inaktiv";
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
