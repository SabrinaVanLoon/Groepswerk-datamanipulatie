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
    /// Interaction logic for VoorwaardenOpdrachtWindow.xaml
    /// </summary>
    public partial class VoorwaardenOpdrachtWindow : Window
    {
        public VoorwaardenOpdrachtWindow()
        {
            InitializeComponent();
        }

        private void btn_TerugOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.Show();
        }

        private void btn_Accepteren_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"Je hebt deze opdracht geaccepteerd", "Geaccepteerd");
 
        }

        //deze methode zorgt ervoor dat het window verdwijnt als je deze verlaat(door op button TerugMenu te drukken)
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            DataGridVoorwaarden.ItemsSource = DatabaseOperations.OphalenGegevensOpdracht();
            
            txbVoorwaarden.Text = Voorwaarden.taakomschrijving + Environment.NewLine + 
                                  Voorwaarden.veld_Id.ToString() + Environment.NewLine +
                                  Voorwaarden.graansoort_Id.ToString() +  Environment.NewLine + 
                                  Voorwaarden.eigenaar_Id.ToString() + Environment.NewLine +  
                                  Voorwaarden.beloning.ToString() +  Environment.NewLine;


            txbVoorwaarden.Text = Voorwaarden.taakomschrijving + Environment.NewLine + Voorwaarden.veld_Id.ToString() + Environment.NewLine +
                Voorwaarden.graansoort_Id.ToString() + Environment.NewLine + Voorwaarden.eigenaar_Id.ToString() + Environment.NewLine + Voorwaarden.beloning.ToString() + Environment.NewLine;


        }

       
    }
}
