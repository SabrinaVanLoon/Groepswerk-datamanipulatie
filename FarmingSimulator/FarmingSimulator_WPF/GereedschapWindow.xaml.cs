using EntityFramework_DAL;
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
using System.Windows.Shapes;
using FarmingSimulator_MODELS;


namespace FarmingSimulator_WPF
{
    /// <summary>
    /// Interaction logic for GereedschapWindow.xaml
    /// </summary>
    public partial class GereedschapWindow : Window
    {
        public GereedschapWindow()
        {
            InitializeComponent();
        }

        private void btnZoekGereedschapOpType_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                List<a_Gereedschap> lijstTypeGereedschap = DatabaseOperations.OphalenGereedschapOpType(txtZoekOpType.Text);
                DataGridGereedschap.ItemsSource = lijstTypeGereedschap;
            }
            else
            {
                MessageBox.Show("Gelieve eerst een type van het gereedschap op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-maaiers" + Environment.NewLine +
                    "\t-maïsplukkers" + Environment.NewLine +
                    "\t-aanhangers" + Environment.NewLine +
                    "\t-gewichten", "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnZoekGereedschapOpNaam_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                List<a_Gereedschap> lijstNamenVoertuig = DatabaseOperations.OphalenGereedschapOpNaam(txtZoekOpNaam.Text);
                DataGridGereedschap.ItemsSource = lijstNamenVoertuig;
            }
            else
            {
                MessageBox.Show("Gelieve eerst een naam van het gereedschap op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-NOVACAT" + Environment.NewLine +
                    "\t-625 X" + Environment.NewLine +
                    "\t-quasar" + Environment.NewLine +
                    "\t-MKE", "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // bij het klikken op deze button(gereedschap kopen) wordt er eerst nagekeken of er iets in de datagrid geselecteerd is,
        // als er iets geselecteerd is en je drukt op de knop, dan komt er een messagebox of je zeker bent dat je dit item wil kopen
        //wil je dit kopen dan komt deze in een lijst van gekochte items(kooplijst)
        //is er niets geselecteerd, en je klikt op de button, dan komt er een messagebox dat je eerst iets moet selecteren
        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
           
          MessageBox.Show("Selecteer eerst een gereedschap!","Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
           



        }



        // bij het klikken op deze button(gereedschap huren) wordt er eerst nagekeken of er iets in de datagrid geselecteerd is,
        // als er iets geselecteerd is en je drukt op de knop, dan komt er een messagebox of je zeker bent dat je dit item wil huren
        //wil je dit huren dan komt deze in een lijst van gehuurde items(huurlijst)
        //is er niets geselecteerd, en je klikt op de button, dan komt er een messagebox dat je eerst iets moet selecteren
        private void btnHuren_Click(object sender, RoutedEventArgs e)
        {
            

          MessageBox.Show("Selecteer eerst een gereedschap!","Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // //bij het klikken op deze button dan ga je terug naar het scherm menu
        private void btnTerugNaarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();    
            
        }


        //deze methode zorgt ervoor dat het window verdwijnt als je deze verlaat(door op button TerugMenu te drukken)
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
