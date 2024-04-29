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

namespace CSH04_Lektion5_2
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

        private void uebernehmen_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                listBox.Items.Add(textBox.Text);
                textBox.Clear();
                textBox.Focus();
                statusLabel.Content = "Eintrag übernommen";
            }
            else
            {
                statusLabel.Content = "Bitte zunächst etwas in die Textbox eintragen!";
            }
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            
            if (listBox.Items.Count == 0)
            {
                statusLabel.Content = "List Empty";
            }
            else if (index >= 0)
            {
                listBox.Items.RemoveAt(index);
                statusLabel.Content = "Das Klicken auf diesen Button löscht den ausgewählten Eintrag";
            }
            else
            {
                statusLabel.Content = "Please select an items in the list";
            }
        }

        private void btnNachOben_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (listBox.Items.Count == 0)
            {
                statusLabel.Content = "List Empty";
            }

            else if (index > 0 )
            {
                index--;
                Verschieben(index);
                statusLabel.Content = "Eintrag oben verschoben";
            }
            else
            {
                statusLabel.Content = "Top of the list";
            }
        }

        private void btnNachUnten_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (listBox.Items.Count == 0)
            {
                statusLabel.Content = "List Empty";
            }
            else if (index < listBox.Items.Count - 1 && index >= 0)
            {
                index++;
                Verschieben(index);
                statusLabel.Content = "Eintrag unten verschoben";
            }
            else
            {
                statusLabel.Content = "bottom of the list";
            }
        }
        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Verschieben(int index)
        {
            Object item = listBox.SelectedItem;
            listBox.Items.Remove(item);
            listBox.Items.Insert(index, item);
            listBox.SelectedIndex = index;
        }

        private void Delete_MouseLeave(object sender, MouseEventArgs e)
        {
            statusLabel.Content = " ";
        }
    }
}

