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

        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAantal.Text) && int.TryParse(txtAantal.Text, out int aantal))
            {
                if (datagridDieren.SelectedItem != null)
                {

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
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
