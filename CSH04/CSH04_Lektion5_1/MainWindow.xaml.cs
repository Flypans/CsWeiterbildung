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

namespace CSH04_Lektion5_1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Anzuzeigender Text", "Titel des Fensters");
            MessageBoxResult result = MessageBox.Show("Hallo, du hast mich angeklickt ?",
                "Test",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information,
                MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                lblAusgabe.Content = "Anwender hat auf JA geklickt";
            }
            else
            {
                lblAusgabe.Content = " Anwender hat auf NEIN geklickt";
            }
        }
    }
}
