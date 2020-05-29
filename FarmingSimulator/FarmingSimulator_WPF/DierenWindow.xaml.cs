using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using EntityFramework_DAL;
using FarmingSimulator_MODELS;

namespace FarmingSimulator_WPF
{
    /// <summary>
    /// Interaction logic for DierenWindow.xaml
    /// </summary>
    public partial class DierenWindow : Window
    {
        public DierenWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridDieren.ItemsSource = DatabaseOperations.OphalenDieren();
        }

        //Het gekozen dier wordt het gegeven aantal keer gekocht
        //de tabel Gekocht_dier wordt opgevuld met de ingelogde speler en het gekozen dier
        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAantal.Text) && int.TryParse(txtAantal.Text, out int aantal))
            {
                if (string.IsNullOrWhiteSpace(Valideer("Dier")))
                {
                    a_Dier dier = datagridDieren.SelectedItem as a_Dier;
                    int yes = 0;
                    for (int i = 0; i < aantal; i++)
                    {
                        a_Gekocht_dier gekocht_Dier = new a_Gekocht_dier();
                        gekocht_Dier.dier_id = dier.Id;
                        gekocht_Dier.speler_id = InlogGegevens.ID;

                        yes = DatabaseOperations.ToevoegenGekochtDier(gekocht_Dier);
                    }

                    if (yes > 0)
                    {
                        MessageBox.Show($"Je hebt {txtAantal.Text} dieren van type {dier.type} gekocht.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Je hebt geen dieren gekocht.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Gelieve een dier te kiezen.", "Dier kopen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Gelieve een aantal in te geven.", "Dier kopen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private string Valideer(string columnName)
        {
            if (columnName == "Dier" && datagridDieren.SelectedItem == null)
            {
                return "Selecteer eerst een item!";
            }
            return "";
        }
    }
}
