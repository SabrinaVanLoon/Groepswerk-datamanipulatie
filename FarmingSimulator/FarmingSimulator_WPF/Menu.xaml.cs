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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnVoertuigen_Click(object sender, RoutedEventArgs e)
        {
            Voertuig voertuig = new Voertuig();
            voertuig.ShowDialog();
        }

        private void btnGereedschap_Click(object sender, RoutedEventArgs e)
        {
            GereedschapWindow gereedschap = new GereedschapWindow();
            gereedschap.ShowDialog();
        }

        private void btnHuurlijst_Click(object sender, RoutedEventArgs e)
        {
            HuurlijstWindow huurlijst = new HuurlijstWindow();
            huurlijst.ShowDialog();
        }

        private void btnKoperslijst_Click(object sender, RoutedEventArgs e)
        {
            KooplijstWindow kopen = new KooplijstWindow();
            kopen.ShowDialog();
        }

        private void btnDieren_Click(object sender, RoutedEventArgs e)
        {
            DierenWindow dieren = new DierenWindow();
            dieren.ShowDialog();
        }

        private void btnOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.ShowDialog();
        }

        private void btnSpeler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void btnVerlaten_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
