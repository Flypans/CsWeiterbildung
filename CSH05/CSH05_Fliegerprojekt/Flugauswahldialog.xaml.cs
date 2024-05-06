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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 
    partial class Flugauswahldialog : Window
    {
        private string dbName;
        public Duesenflugzeug Flugauswahl
        {
            get
            {
                return (Duesenflugzeug)cBoxFluege.SelectedItem;
            }
        }

        public Flugauswahldialog(string dbName)
        {
            this.dbName = dbName;

            InitializeComponent();
            Flugauswahldialog_Load();
        }

        private void Flugauswahldialog_Load()
        {
            IObjectContainer db = null;

            try
            {
                db = Db4oFactory.OpenFile(dbName);
                IObjectSet result = db.QueryByExample(typeof(Duesenflugzeug));

                while (result.HasNext())
                {
                    cBoxFluege.Items.Add(result.Next());

                    // add Query Result to ComboBox
                    //Duesenflugzeug flugzeug = (Duesenflugzeug)result.Next();
                    //cBoxFluege.Items.Add(flugzeug); 

                    cBoxFluege.SelectedIndex = 0;
                    //cBoxFluege.SelectedIndex = cBoxFluege.Items.Count -1;

                }
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

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
