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
            this.flieger = flieger; //member variable

            InitializeComponent(); //WPF 
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
            flieger.Kennung = tbKennung.Text; // call by reference

            if (flieger.Kennung.Length == 0)
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

        public void SetEingabewerte(Duesenflugzeug flieger)
        {
            //textBoxKennung.Text = "LH 500";
            //textBoxStartPosX.Text = "100";

            //tbKennung.Text = "LH 500";
            //tbKennung.Text = "100";

            tbKennung.Text = flieger.Kennung;
            cbTyp.SelectedItem = flieger.typ;

            tbStartX.Text = flieger.pos.x.ToString();
            tbStartY.Text = flieger.pos.y.ToString();
            tbStartH.Text = flieger.pos.h.ToString();

            tbZielX.Text = flieger.zielPos.x.ToString();
            tbZielY.Text = flieger.zielPos.y.ToString();
            tbZielH.Text = flieger.zielPos.h.ToString();

            tbFlughoehe.Text = flieger.flughoehe.ToString();

            tbSteighoehe.Text = flieger.steighoeheProTakt.ToString();
            tbSinkhoehe.Text = flieger.sinkhoeheProTakt.ToString();

            tbFlugstrecke.Text = flieger.streckeProTakt.ToString();
            tbAnzahlPlaetze.Text = flieger.sitzplaetze.ToString();
        }
        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string dbName = "FliegerDB";
        private void buttonSpeichern_Click(object sender, RoutedEventArgs e)
        {
            IObjectContainer db = null; // declare and initialize the variable db

            //This variable is used to track whether an update operation is needed in the database. 
            bool update = false;

            try
            {
                db = Db4oFactory.OpenFile(dbName);

                //DB-Update-Arbeitsobjekts [
                IList<Duesenflugzeug> fluege = db.Query<Duesenflugzeug>(
                    delegate (Duesenflugzeug flieger)
                    {
                        return flieger.Kennung == tbKennung.Text;
                    });

                foreach (Duesenflugzeug flieger in fluege)
                {
                    Console.WriteLine("Flug mit der Kennung {0} in Datenbank gefunden", flieger.Kennung);
                }

                if (fluege.Count > 0)
                {
                    flieger = fluege.First();
                    update = true;
                }
                //DB-Update-Arbeitsobjekts ]
                this.initializeFlieger();
                db.Store(flieger);

                //DB-Update-Arbeitsobjekts [
                if (update)
                {
                    Console.WriteLine("Datenbank-Update für den Flug mit der kennung {0}", flieger.Kennung);
                }
                else
                {
                    Console.WriteLine("Flug mit der Kennung{0} in der Datenbank gespeichert", flieger.Kennung);
                }
                //DB-Update-Arbeitsobjekts ]
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType() + ": " + ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
        }
        private void buttonLaden_Click(object sender, EventArgs e)
        {
            //Flugauswahldialog flugauswahlDialog = new Flugauswahldialog(dbName);
            //flugauswahlDialog.ShowDialog();

            Flugauswahldialog select = new Flugauswahldialog(dbName);
            select.Height = 200;
            select.Width = 400;

            //if (result == DialogResult.OK)
            if(select.ShowDialog() == true)
            {
                flieger = select.Flugauswahl;
                this.SetEingabewerte(flieger);

                Console.WriteLine("Flug \"{0}\" geladen", flieger.Kennung);
            }
            else
            {
                Console.WriteLine("Flugauswahl abgebrochen");
            }
        }
    }
}
