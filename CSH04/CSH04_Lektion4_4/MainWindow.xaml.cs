﻿using System;
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

namespace CSH04_Lektion4_4
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

        private void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(listBox);

            listBox.Items.Clear();
            listBox.Items.Add($"Mouse Position: X={position.X}, Y={position.Y}");
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            listBox.Items.Add("You left the Button area !");
        }
    }
}
