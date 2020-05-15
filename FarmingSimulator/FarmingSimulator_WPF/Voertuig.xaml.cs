﻿using EntityFramework_DAL;
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
            string foutmeldingen = Valideer("type");
            if (!string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                List<a_Voertuig> lijstTypeVoertuig = DatabaseOperations.OphalenVoertuigenOpType(txtZoekOpType.Text);
                DataGridVoertuig.ItemsSource = lijstTypeVoertuig;
            }
            else
            {
                MessageBox.Show(foutmeldingen, "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnZoekVoertuigOpNaam_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("naam");
            if (!string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                List<a_Voertuig> lijstNamenVoertuig = DatabaseOperations.OphalenVoertuigenOpNaam(txtZoekOpNaam.Text);
                DataGridVoertuig.ItemsSource = lijstNamenVoertuig;
            }
            else
            {
                MessageBox.Show(foutmeldingen, "Opgelet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnKopen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Voertuig");

            a_Voertuig voertuig = (a_Voertuig)DataGridVoertuig.SelectedItem;

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                MessageBoxResult antwoord = MessageBox.Show($"Dit voertuig kopen? {Environment.NewLine} {voertuig.naam} {voertuig.merk} {voertuig.type}", "IN WINKELWAGEN", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {
                    a_GekochtVoertuig gekochtvoertuig = new a_GekochtVoertuig();
                    gekochtvoertuig.voertuig_Id = voertuig.Id;
                    gekochtvoertuig.speler_Id = 1;

                    int yes = DatabaseOperations.ToevoegenGekochtVoertuig(gekochtvoertuig);

                    if (yes > 0)
                    {
                        KooplijstWindow gekocht = new KooplijstWindow();
                        gekocht.ShowDialog();
                    }
                }
            }
        }

        private void btnHuren_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("Voertuig");

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                a_Voertuig voertuig = (a_Voertuig)DataGridVoertuig.SelectedItem;
                MessageBoxResult antwoord = MessageBox.Show($"Dit voertuig huren? {Environment.NewLine} {voertuig.naam} {voertuig.merk} {voertuig.type}", "IN WINKELWAGEN", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes)
                {
                    a_GehuurdVoertuig gehuurdVoertuig = new a_GehuurdVoertuig();
                    gehuurdVoertuig.voertuig_Id = voertuig.Id;
                    gehuurdVoertuig.speler_Id = 1;


                    int yes = DatabaseOperations.ToevoegenGehuurdVoertuig(gehuurdVoertuig);

                    if (yes > 0)
                    {
                        HuurlijstWindow gekocht = new HuurlijstWindow();
                        gekocht.ShowDialog();
                    }
                }
            }
        }

        private void btnTerugNaarMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }
        private string Valideer(string columnName)
        {
            if (columnName == "Voertuig" && DataGridVoertuig.SelectedItem == null)
            {
                return "Selecteer een voertuig aub!" + Environment.NewLine;
            }
            if (columnName == "naam" && string.IsNullOrWhiteSpace(txtZoekOpNaam.Text))
            {
                return "Gelieve eerst een naam van het voertuig op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-MF 5600" + Environment.NewLine +
                    "\t-500 Favorit" + Environment.NewLine +
                    "\t-Series" + Environment.NewLine +
                    "\t-Pickup";
            }
            if (columnName == "type" && string.IsNullOrWhiteSpace(txtZoekOpType.Text))
            {
                return "Gelieve eerst een type van het voertuig op te geven!" + Environment.NewLine + "Bijvoorbeeld:" + Environment.NewLine +
                    "\t-auto" + Environment.NewLine +
                    "\t-oogstmachines" + Environment.NewLine +
                    "\t-tractoren" + Environment.NewLine +
                    "\t-katoentechnologie";
            }
            return "";
        }

        private void DataGridVoertuig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridVoertuig.SelectedItem is a_Voertuig voertuig)
            {
                txtZoekOpNaam.Text = voertuig.naam;
                txtZoekOpType.Text = voertuig.type;
            }
        }
    }
}
