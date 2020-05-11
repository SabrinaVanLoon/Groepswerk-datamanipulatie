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
<<<<<<< Updated upstream
=======

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<a_Dier> LijstDieren = DatabaseOperations.OphalenDieren();
            datagridDieren.ItemsSource = LijstDieren;
        }

        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }
>>>>>>> Stashed changes
    }
}
