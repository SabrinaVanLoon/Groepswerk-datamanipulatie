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
    /// Interaction logic for HuurlijstWindow.xaml
    /// </summary>
    public partial class HuurlijstWindow : Window
    {
        public HuurlijstWindow()
        {
            InitializeComponent();
        }

        // bij het laden van deze window wordt meteen de lijst getoond van alles wat gehuurd is
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridHuurlijst.ItemsSource = DatabaseOperations.OphalenGehuurdGereedschap();


        }

        //verwijderen uit de lijst van gehuurdGereedschap
        private void btn_hurenStopzetten_Click(object sender, RoutedEventArgs e) 
        {

        }

        //bij het klikken op deze button ga je naar het scherm van winkel voertuig (voertuig.xaml)
        private void btn_WinkelVoertuigen_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Voertuig voertuigwinkel = new Voertuig();
            voertuigwinkel.Show();
        }


        //bij het klikken op deze button ga je naar het scherm van winkel gereedschap (gereedschapWindow.xaml)
        private void btn_WinkelGereedschap_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GereedschapWindow gereedschapwinkel = new GereedschapWindow();
            gereedschapwinkel.Show();
        }

        //bij het klikken op deze button dan ga je terug naar het scherm menu
        private void btn_TerugMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
            
        }

       
        //deze methode zorgt ervoor dat het window verdwijnt als je deze verlaat(door op button TerugMenu te drukken)
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
