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
    /// Interaction logic for Voertuig.xaml
    /// </summary>
    public partial class Voertuig : Window
    {
        public Voertuig()
        {
            InitializeComponent();
        }

        private void btnZoekVoertuigOpType_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                List<a_Voertuig> lijstTypeVoertuig = DatabaseOperations.OphalenVoertuigenOpType(txtZoekOpType.Text);
                DataGridVoertuig.ItemsSource = lijstTypeVoertuig;
            }
            else
            {
                MessageBox.Show("Gelieve eerst een type van het voertuig op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-auto" + Environment.NewLine +
                    "\t-oogstmachines" + Environment.NewLine +
                    "\t-tractoren" + Environment.NewLine +
                    "\t-katoentechnologie", "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnZoekVoertuigOpNaam_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                List<a_Voertuig> lijstNamenVoertuig = DatabaseOperations.OphalenVoertuigenOpNaam(txtZoekOpNaam.Text);
                DataGridVoertuig.ItemsSource = lijstNamenVoertuig;
            }
            else
            {
                MessageBox.Show("Gelieve eerst een naam van het voertuig op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-MF 5600" + Environment.NewLine +
                    "\t-500 Favorit" + Environment.NewLine +
                    "\t-Series" + Environment.NewLine +
                    "\t-Pickup", "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHuren_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTerugNaarMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
