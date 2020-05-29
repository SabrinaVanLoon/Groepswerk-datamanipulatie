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
using EntityFramework_DAL;
using FarmingSimulator_MODELS;

namespace FarmingSimulator_WPF
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSpelers.ItemsSource = DatabaseOperations.OphalenSpelers();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSpelers.SelectedItem is a_Speler speler)
            {
                InlogGegevens.ID = speler.Id;
                InlogGegevens.Naam = speler.naam;
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gelieve een speler te kiezen", "Spel starten", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnNieuweSpeler_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNieuweSpeler.Text))
            {
                a_Speler speler = new a_Speler();
                speler.naam = txtNieuweSpeler.Text;
                MessageBoxResult antwoord = MessageBox.Show($"Deze speler toevoegen? {Environment.NewLine} {speler.naam}", "Speler toevoegen", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (speler.IsGeldig())
                {
                    if (antwoord == MessageBoxResult.Yes)
                    {
                        speler.level = 0;
                        speler.kapitaal = 10000;

                        MessageBoxResult Geslacht = MessageBox.Show("Is de speler een man?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (Geslacht == MessageBoxResult.Yes)
                        {
                            speler.geslacht = "man";
                        }
                        else
                        {
                            speler.geslacht = "vrouw";
                        }

                        DatabaseOperations.ToevoegenSpeler(speler);
                        cmbSpelers.ItemsSource = DatabaseOperations.OphalenSpelers();
                    }
                }
                else
                {
                    MessageBox.Show(speler.Error, "Foutmelding");
                }
            }
            else
            {
                MessageBox.Show("Gelieve een naam voor de nieuwe speler in te geven.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
