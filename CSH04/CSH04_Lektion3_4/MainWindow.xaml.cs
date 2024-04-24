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

namespace CSH04_Lektion3_4
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
        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void uebernehmen_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add(textBox.Text);
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.ScrollIntoView(listBox.SelectedIndex);

            textBox.Text = "";
        }

        private void btnNachOben_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index == 0 && index >0)
                index = listBox.Items.Count - 1;
            else
                index--;

            Verschieben(index);
        }

        private void btnNachUnten_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            int lastIndex = listBox.Items.Count - 1;

            if (index == listBox.Items.Count - 1 && index > lastIndex)
                index = 0;
            else 
                index++;

            Verschieben(index);
        }

        private void Verschieben(int index)
        {
            Object item = listBox.SelectedItem;
            listBox.Items.Remove(item);
            listBox.Items.Insert(index, item);
            listBox.SelectedIndex = index;
        }

        private void btnLoeschen_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;

            listBox.Items.RemoveAt(index);
        }
    }
}
