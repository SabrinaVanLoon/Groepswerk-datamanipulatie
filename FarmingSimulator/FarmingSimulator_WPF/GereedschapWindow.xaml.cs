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
            string foutmeldingen = Valideer("type");
            if (!string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                List<a_Gereedschap> lijstTypeGereedschap = DatabaseOperations.OphalenGereedschapOpType(txtZoekOpType.Text);
                DataGridGereedschap.ItemsSource = lijstTypeGereedschap;
            }
            else
            {
                MessageBox.Show(foutmeldingen, "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btnZoekGereedschapOpNaam_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("naam");
            if (!string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                List<a_Gereedschap> lijstNamenGereedschap = DatabaseOperations.OphalenGereedschapOpNaam(txtZoekOpNaam.Text);
                DataGridGereedschap.ItemsSource = lijstNamenGereedschap;
            }
            else
            {
                MessageBox.Show(foutmeldingen, "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
        }

        // bij het klikken op deze button(gereedschap kopen) wordt er eerst nagekeken of er iets in de datagrid geselecteerd is,
        // als er iets geselecteerd is en je drukt op de knop, dan komt er een messagebox of je zeker bent dat je dit item wil kopen
        //wil je dit kopen dan komt deze in een lijst van gekochte items(kooplijst)
        //is er niets geselecteerd, en je klikt op de button, dan komt er een messagebox dat je eerst iets moet selecteren
        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Wil je dit gereedschap kopen?  {Environment.NewLine} {gereedschap.naam} {gereedschap.merk} {gereedschap.type}", "Winkelwagen", MessageBoxButton.YesNo);
            if (!string.IsNullOrWhiteSpace(txtAantal.Text) && int.TryParse(txtAantal.Text, out int aantal))
            {               
                if (string.IsNullOrWhiteSpace(Valideer("Gereedschap")))
                {
                    a_Gereedschap gereedschap = DataGridGereedschap.SelectedItem as a_Gereedschap;
                    int yes = 0;
                    for (int i = 0; i < aantal; i++)
                    {
                        a_GekochtGereedschap gekochtGereedschap = new a_GekochtGereedschap();
                        gekochtGereedschap.gereedschap_Id = gereedschap.Id;
                        gekochtGereedschap.speler_Id = InlogGegevens.ID;
                        yes = DatabaseOperations.ToevoegenGekochtGereedschap(gekochtGereedschap);
                    }
                    if (yes > 0)
                    {
                        MessageBox.Show($"Je hebt {txtAantal.Text} {gereedschap.naam} van het type {gereedschap.type} gekocht", "Opgelet", MessageBoxButton.OK);
                        KooplijstWindow garage = new KooplijstWindow();
                        garage.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Je hebt geen gereedschap gekocht.", "fout", MessageBoxButton.OK);
                    }                   
                }
                else
                {
                    MessageBox.Show("Gelieve een item te selecteren", "Opgelet", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Gelieve een aantal in te geven", "Opgelet", MessageBoxButton.OK);
            }
        }
       


        // bij het klikken op deze button(gereedschap huren) wordt er eerst nagekeken of er iets in de datagrid geselecteerd is,
        // als er iets geselecteerd is en je drukt op de knop, dan komt er een messagebox of je zeker bent dat je dit item wil huren
        //wil je dit huren dan komt deze in een lijst van gehuurde items(huurlijst)
        //is er niets geselecteerd, en je klikt op de button, dan komt er een messagebox dat je eerst iets moet selecteren
        private void btnHuren_Click(object sender, RoutedEventArgs e) //werkt enkel moet er het naam, merk enzo verschijnen van het gereedschap
        {           
            //    MessageBoxResult antwoord = MessageBox.Show($"Wil je dit gereedschap huren?  {Environment.NewLine} {gereedschap.naam} {gereedschap.merk} {gereedschap.type}", "Winkelwagen", MessageBoxButton.YesNo);           
            if (!string.IsNullOrWhiteSpace(txtAantal.Text) && int.TryParse(txtAantal.Text, out int aantal))
            {               
                if (string.IsNullOrWhiteSpace(Valideer("Gereedschap")))
                {
                    a_Gereedschap gereedschap = DataGridGereedschap.SelectedItem as a_Gereedschap;
                    int yes = 0;
                    for (int i = 0; i < aantal; i++)
                    {
                        a_GehuurdGereedschap gehuurdGereedschap = new a_GehuurdGereedschap();
                        gehuurdGereedschap.gereedschap_Id = gereedschap.Id;
                        gehuurdGereedschap.speler_Id = InlogGegevens.ID;
                        yes = DatabaseOperations.ToevoegenGehuurdGereedschap(gehuurdGereedschap);
                    }
                    if (yes > 0)

                    {
                        
                        MessageBox.Show($"Je hebt {txtAantal.Text} {gereedschap.naam} van het type {gereedschap.type} gehuurd", "Opgelet", MessageBoxButton.OK);
                        HuurlijstWindow gehuurdGereedschapwindow = new HuurlijstWindow();
                        gehuurdGereedschapwindow.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Je hebt geen gereedschap gehuurd.", "fout", MessageBoxButton.OK);
                        
                    }                   
                }
                else
                {
                    MessageBox.Show("Gelieve een item te selecteren", "Opgelet", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Gelieve een aantal in te geven", "Opgelet", MessageBoxButton.OK);
            }
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

        private string Valideer(string columnName)
        {
            if (columnName == "Gereedschap" && DataGridGereedschap.SelectedItem == null)
            {
                return "Selecteer eerst een gereedschap!";
            }
            if (columnName == "naam" && string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                return "Gelieve eerst een naam van het gereedschap op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-NOVACAT" + Environment.NewLine +
                    "\t-625 X" + Environment.NewLine +
                    "\t-quasar" + Environment.NewLine +
                    "\t-MKE";
            }
            if (columnName == "type" && string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                return "Gelieve eerst een type van het gereedschap op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-maaiers" + Environment.NewLine +
                    "\t-maïsplukkers" + Environment.NewLine +
                    "\t-aanhangers" + Environment.NewLine +
                    "\t-gewichten";
            }
            return "";
        }

        private void DataGridGereedschap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridGereedschap.SelectedItem is a_Gereedschap gereedschap)
            {
                txtZoekOpNaam.Text = gereedschap.naam;
                txtZoekOpType.Text = gereedschap.type;
            }
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Gereedschap");
            foutmeldingen += Valideer("naam");
            foutmeldingen += Valideer("type");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                a_Gereedschap gereedschap = DataGridGereedschap.SelectedItem as a_Gereedschap;
                gereedschap.naam = txtZoekOpNaam.Text;
                if (gereedschap.IsGeldig())
                {
                    int ok = DatabaseOperations.AanpassenGereedschap(gereedschap);
                    if (ok > 0)
                    {
                        DataGridGereedschap.ItemsSource = DatabaseOperations.OphalenGereedschapOpNaam(gereedschap.naam);
                        
                        Resetten();
                    }
                    else
                    {
                        MessageBox.Show("Gereedschap is niet aangepast");
                    }
                }
                else
                {
                    MessageBox.Show(foutmeldingen);
                }
            }
        }

        private void Resetten()
        {
            DataGridGereedschap.SelectedIndex = -1;           
        }

    }
}