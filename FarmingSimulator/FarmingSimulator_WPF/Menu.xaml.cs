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
            this.Hide();
            Voertuig voertuig = new Voertuig();
            voertuig.ShowDialog();
            this.Close();
        }

        private void btnGereedschap_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GereedschapWindow gereedschap = new GereedschapWindow();
            gereedschap.ShowDialog();
            this.Close();
        }

        private void btnHuurlijst_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HuurlijstWindow huurlijst = new HuurlijstWindow();
            huurlijst.ShowDialog();
            this.Close();
        }

        private void btnKoperslijst_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            KooplijstWindow kopen = new KooplijstWindow();
            kopen.ShowDialog();
            this.Close();
        }

        private void btnDieren_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DierenWindow dieren = new DierenWindow();
            dieren.ShowDialog();
            this.Close();
        }

        private void btnOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.ShowDialog();
            this.Close();
        }

        private void btnSpeler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();
            this.Close();
        }

        private void btnVerlaten_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
