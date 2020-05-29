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

namespace FarmingSimulator_WPF
{
    /// <summary>
    /// Interaction logic for HuurlijstWindow.xaml
    /// </summary>
    public partial class HuurlijstWindow : Window
    {
        public HuurlijstWindow()
        {
            InitializeComponent();
        }

        // bij het laden van deze window wordt meteen de lijst getoond van alles wat gehuurd is
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridHuurlijstGereedschap.ItemsSource = DatabaseOperations.OphalenGehuurdGereedschap();
            DataGridHuurlijstVoertuig.ItemsSource = DatabaseOperations.OphalenGehuurdVoertuig();

        }

        //verwijderen uit de lijst van gehuurdGereedschap of gehuurdVoertuig
        private void btn_hurenStopzetten_Click(object sender, RoutedEventArgs e)
        {           
            if (string.IsNullOrWhiteSpace(ValideerGereedschap("Gereedschap")))
            {
                a_GehuurdGereedschap gehuurdgereedschap = DataGridHuurlijstGereedschap.SelectedItem as a_GehuurdGereedschap;
                MessageBoxResult antwoord = MessageBox.Show($"Wil je huren opzeggen?", "Huurlijst", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (antwoord == MessageBoxResult.Yes)
                {

                    DatabaseOperations.VerwijderGehuurdGereedschapHuurlijst(gehuurdgereedschap);
                    //Resetten();
                    DataGridHuurlijstGereedschap.ItemsSource = DatabaseOperations.OphalenGehuurdGereedschap();

                }
                else
                {
                    MessageBox.Show("Geselecteerd item is niet verwijderd.", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (string.IsNullOrWhiteSpace(Valideervoertuig("Voertuig")))
            {
                a_GehuurdVoertuig gehuurdvoertuig = DataGridHuurlijstVoertuig.SelectedItem as a_GehuurdVoertuig;
                MessageBoxResult antwoord = MessageBox.Show($"Wil je huren opzeggen?", "Huurlijst", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {

                    DatabaseOperations.VerwijderGehuurdVoertuigHuurlijst(gehuurdvoertuig);
                    //Resetten();
                    DataGridHuurlijstVoertuig.ItemsSource = DatabaseOperations.OphalenGehuurdVoertuig();
                }
                else
                {
                    MessageBox.Show("Geselecteerd item is niet verwijderd.","Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Gelieve een item te selecteren!", "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //bij het klikken op deze button ga je naar het scherm van winkel voertuig (voertuig.xaml)
        private void btn_WinkelVoertuigen_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Voertuig voertuigwinkel = new Voertuig();
            voertuigwinkel.Show();
            this.Close();
        }


        //bij het klikken op deze button ga je naar het scherm van winkel gereedschap (gereedschapWindow.xaml)
        private void btn_WinkelGereedschap_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GereedschapWindow gereedschapwinkel = new GereedschapWindow();
            gereedschapwinkel.Show();
            this.Close();
        }

        //bij het klikken op deze button dan ga je terug naar het scherm menu
        private void btn_TerugMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
            this.Close();

        }

        private string ValideerGereedschap(string columnName)
        {
            if (columnName== "Gereedschap" && DataGridHuurlijstGereedschap.SelectedItem == null)
            {
                return "Selecteer een item";

            }
            return "";
        }

        private string Valideervoertuig(string columnName)
        {
            if (columnName == "Voertuig" && DataGridHuurlijstVoertuig.SelectedItem == null)
            {
                return "Selecteer een item";

            }
            return "";
        }

        //private void Resetten()
        //{
        //    DataGridHuurlijstGereedschap.SelectedIndex = -1;
        //    DataGridHuurlijstVoertuig.SelectedIndex = -1;
        //}

    }
}
