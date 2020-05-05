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
