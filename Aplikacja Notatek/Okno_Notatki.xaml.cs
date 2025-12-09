using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplikacja_Notatek
{
    /// <summary>
    /// Logika interakcji dla klasy Okno_Notatki.xaml
    /// </summary>
    public partial class Okno_Notatki : Window
    {
        private int counternotatki = 0;
        private int numberofnotes = 0;

        public Okno_Notatki()
        {

            InitializeComponent();
            while (File.Exists("Notatka" + counternotatki + ".txt") == true)
            {
                ListaNotatek.Items.Add("Notatka" + counternotatki + ".txt \n");
                counternotatki++;
            }
            counternotatki = ListaNotatek.Items.Count;
        }
        private void Zapisz_Notatke(object sender, RoutedEventArgs e)
        {
            
            string Tekst_Notatki = PoleNotatki.Text;
            string temp;
            if(ListaNotatek.Items.Count != 0)
            {
                temp = ListaNotatek.SelectedItem.ToString();
                temp = Regex.Match(temp, @"\d+").Value;

                counternotatki = int.Parse(temp);
            }
            

            File.WriteAllText("Notatka" + counternotatki + ".txt", Tekst_Notatki);
            numberofnotes++;

            MessageBox.Show("Notatka została zapisana!");

            counternotatki = ListaNotatek.Items.Count;
            while (File.Exists("Notatka" + counternotatki + ".txt") == true)
            {
                ListaNotatek.Items.Add("Notatka" + counternotatki + ".txt \n");
                counternotatki++;
            }
            counternotatki = ListaNotatek.Items.Count;

        }

        private void Powrot_Menu_Glowne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Wybor_Notatki(object sender, RoutedEventArgs e)
        {
            string wybor = ListaNotatek.SelectedItem.ToString();
            if(wybor != null)
            {
                PoleNotatki.Text = File.ReadAllText(wybor.Trim());
            }

        }
    }
}
