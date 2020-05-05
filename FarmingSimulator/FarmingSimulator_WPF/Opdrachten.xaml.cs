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

        }

        private void btnTerugNaarMenu_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<a_Opdracht> lijstVanOpdrachten = DatabaseOperations.OphalenVolledigeLijstOpdrachten();
            DataGridOpdrachten.ItemsSource = lijstVanOpdrachten;
        }


    }
}
