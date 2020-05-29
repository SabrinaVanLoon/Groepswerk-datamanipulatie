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
    /// Interaction logic for KooplijstWindow.xaml
    /// </summary>
    public partial class KooplijstWindow : Window
    {
        public KooplijstWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<a_GekochtVoertuig> gekochtVoertuig = DatabaseOperations.OphalenGekochteVoertuigen();
            DataGridVoertuigen.ItemsSource = gekochtVoertuig;

            List<a_GekochtGereedschap> gekochtGereeedschap = DatabaseOperations.OphalenGekochteGereedschappen();
            DataGridGereedschappen.ItemsSource = gekochtGereeedschap;

            List<a_Gekocht_dier> gekochtDier = DatabaseOperations.OphalenGekochteDieren();
            DataGridDieren.ItemsSource = gekochtDier;
        }

        private void btnVoertuigVerkopen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Valideer("Voertuig")))
            {
                a_GekochtVoertuig gekochtVoertuig = DataGridVoertuigen.SelectedItem as a_GekochtVoertuig;
                MessageBoxResult antwoord = MessageBox.Show($"Wil je dit voertuig verkopen?", "Verkopen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {
                    DatabaseOperations.VerwijderGekochtVoertuig(gekochtVoertuig);
                    DataGridVoertuigen.ItemsSource = DatabaseOperations.OphalenGekochteVoertuigen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een item!", "Verkopen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGereedschapVerkopen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Valideer("Gereedschap")))
            {
                a_GekochtGereedschap gekochtGereedschap = DataGridGereedschappen.SelectedItem as a_GekochtGereedschap;
                MessageBoxResult antwoord = MessageBox.Show($"Wil je dit gereedschap verkopen?", "Verkopen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {
                    DatabaseOperations.VerwijderGekochtGereedschap(gekochtGereedschap);
                    DataGridGereedschappen.ItemsSource = DatabaseOperations.OphalenGekochteGereedschappen();
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een item!", "Verkopen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDierVerkopen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Valideer("Dier")))
            {
                a_Gekocht_dier gekochtDier = DataGridDieren.SelectedItem as a_Gekocht_dier;
                MessageBoxResult antwoord = MessageBox.Show($"Wil je dit dier verkopen?", "Verkopen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {
                    DatabaseOperations.VerwijderGekochtDier(gekochtDier);
                    DataGridDieren.ItemsSource = DatabaseOperations.OphalenGekochteDieren();
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een item!", "Verkopen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVoertuigwinkel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Voertuig winkel = new Voertuig();
            winkel.ShowDialog();
        }

        private void btnGereedschapwinkel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GereedschapWindow winkel = new GereedschapWindow();
            winkel.ShowDialog();
        }

        private void btnDierenwinkel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DierenWindow winkel = new DierenWindow();
            winkel.ShowDialog();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private string Valideer(string columnName)
        {
            if (columnName == "Voertuig" && DataGridVoertuigen.SelectedItem == null)
            {
                return "Selecteer eerst een item!";
            }

            if (columnName == "Gereedschap" && DataGridGereedschappen.SelectedItem == null)
            {
                return "Selecteer eerst een item!";
            }

            if (columnName == "Dier" && DataGridDieren.SelectedItem == null)
            {
                return "Selecteer eerst een item!";
            }
            return "";
        }
    }
}
