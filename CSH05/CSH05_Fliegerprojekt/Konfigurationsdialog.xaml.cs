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

namespace CSH05_Fliegerprojekt
{
    /// <summary>
    /// Interaction logic for Konfigurationsdialog.xaml
    /// </summary>
    public partial class Konfigurationsdialog : Window
    {
        public Konfigurationsdialog(Duesenflugzeug flieger)
        {
            InitializeComponent();
            Konfigurationsdialog_Load();
        }

        private void Konfigurationsdialog_Load()

        {
            foreach (Airbus element in Enum.GetValues(typeof(Airbus)))
            {
                cbTyp.Items.Add(element);
            }
            cbTyp.SelectedIndex = 0;// Default
        }

        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
