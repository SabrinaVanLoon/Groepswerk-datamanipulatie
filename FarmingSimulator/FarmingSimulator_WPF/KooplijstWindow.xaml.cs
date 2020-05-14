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
            DataGridKooplijst.ItemsSource = gekochtVoertuig;
        }
    }
}
