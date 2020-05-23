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
    /// Interaction logic for Opdrachten.xaml
    /// </summary>
    public partial class Opdrachten : Window
    {
        public Opdrachten()
        {
            InitializeComponent();
        }


        private void btnBekijk_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Opdrachten");

            a_Opdracht opdracht = (a_Opdracht)DataGridOpdrachten.SelectedItem;

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                VoorwaardenOpdrachtWindow voorwaardenVoorOpdracht = new VoorwaardenOpdrachtWindow(opdracht);               
                voorwaardenVoorOpdracht.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(foutmeldingen, "fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTerugNaarMenu_Click_1(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<a_Opdracht> lijstVanOpdrachten = DatabaseOperations.OphalenVolledigeLijstOpdrachten();
            DataGridOpdrachten.ItemsSource = lijstVanOpdrachten;
        }

        private string Valideer(string columnName)
        {
            if (columnName == "Opdrachten" && DataGridOpdrachten.SelectedItem == null)
            {
                return "Selecteer een opdracht om deze te bekijken aub!";
            }
            return "";
        }
    }
}
