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
using Db4objects.Db4o;

namespace CSH05_Fliegerprojekt
{
    /// <summary>
    /// Interaction logic for Konfigurationsdialog.xaml
    /// </summary>
    partial class Konfigurationsdialog : Window
    {
        private Duesenflugzeug flieger;
        private bool isConfigurationComplete;

        public Konfigurationsdialog(Duesenflugzeug flieger)
        {
            this.flieger = flieger;

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

        private void initializeFlieger()
        {
            flieger.Kennung = tbKennung.Text;

            if(flieger.Kennung.Length == 0)
            {
                Console.WriteLine("Fliegerkennung nicht gesetzt");
                isConfigurationComplete = false;
            }
            flieger.typ = (Airbus)cbTyp.SelectedItem;

            try
            {
                flieger.pos = new
                    Position(Int32.Parse(tbStartH.Text),
                    Int32.Parse(tbStartY.Text),
                    Int32.Parse(tbStartH.Text));
            }
            catch (Exception)
            {
                Console.WriteLine("Startpositionsvariablen nicht gesetzt");
                isConfigurationComplete = false;
            }
        }

        private void SetEingabewerte()
        {
            //textBoxKennung.Text = "LH 500";
            //textBoxStartPosX.Text = "100";

            tbKennung.Text = "LH 500";
            tbKennung.Text = "100";
        }
        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string dbName = "FliegerDB";
        private void buttonSpeichern_Click(object sender, RoutedEventArgs e)
        {
            IObjectContainer db = null;

            try
            {
                db = Db4oFactory.OpenFile(dbName);

                this.initializeFlieger();
                db.Store(flieger);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType() + ": " + ex.Message);
            }
            finally
            {
                if(db != null)
                {
                    db.Close();
                }
            }
        }
    }
}
