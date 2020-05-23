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
        private a_Opdracht opdracht = new a_Opdracht();
        public VoorwaardenOpdrachtWindow()
        {
            InitializeComponent();
        }
        public VoorwaardenOpdrachtWindow(a_Opdracht opdracht)
        {
            this.opdracht = opdracht;
            InitializeComponent();
        }
        private void btn_TerugOpdrachten_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Opdrachten opdrachten = new Opdrachten();
            opdrachten.Show();
            this.Close();
        }

        private void btn_Accepteren_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"Je hebt deze opdracht geaccepteerd!", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
 
        }

        ////deze methode zorgt ervoor dat het window verdwijnt als je deze verlaat(door op button TerugMenu te drukken)
        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Menu menu = new Menu();
        //    menu.Show();
        //    this.Close();
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rndNamen = new Random();
            string[] boer = { "Rufus", "Luc", "Victor", "Fido", "Sisco" };
            string[] boerin = { "Maggie", "Penny", "Sophie", "Anita", "Abby" };
            int man = rndNamen.Next(boer.Length);
            int vrouw = rndNamen.Next(boerin.Length);
            Random rndGetalTotVoltooienOpdracht = new Random();

            txbVoorwaarden.Text = "";

            List<a_Graansoort> graanEnEffect = DatabaseOperations.OphalenGraansoortenEnWeerseffect(opdracht.Id);
            foreach (var opdracht in graanEnEffect)
            {
                foreach (var taak in opdracht.a_Opdrachten)
                {
                    txbVoorwaarden.Text = $"Je koos voor {taak.taakomschrijving}. {Environment.NewLine}" +
                       $"Deze opdracht vind plaats op veldnummer {taak.veld_Id} bij boer {boer[man]} en boerin {boerin[vrouw]}. {Environment.NewLine}{Environment.NewLine}";
                    foreach (var hetWeer in opdracht.a_Weerseffectten)
                    {
                        txbVoorwaarden.Text += $"bij {hetWeer.a_Weersomstandigheid.status} (weer) mag je {hetWeer.effect}. {Environment.NewLine}{Environment.NewLine}";
                    }
                    txbVoorwaarden.Text += $"Bij het accepteren van de opdracht krijg je {rndGetalTotVoltooienOpdracht.Next(5, 15)} dagen tijd om deze te voltooien. {Environment.NewLine}" +
                        $"Bij het succesvol voltooien van de opdracht verdien je {taak.beloning} €.";
                }
            }




        }

       
    }
}
