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
        private string[] notatki = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

        public Okno_Notatki()
        {
            InitializeComponent();

            if (notatki.Length > 0)
            {
                Odswiez_Notatki();
            }

        }
        private void Zapisz_Notatke(object sender, RoutedEventArgs e)
        {


            string Tekst_Notatki = PoleNotatki.Text;

            if (ListaNotatek.SelectedItem != null)
            {
                string wybrana_notatka = ListaNotatek.SelectedItem.ToString();

                File.WriteAllText(wybrana_notatka, Tekst_Notatki);

                Odswiez_Notatki();
            }

        }

        private void Powrot_Menu_Glowne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Wybor_Notatki(object sender, RoutedEventArgs e)
        {
            string wybor = ListaNotatek.SelectedItem.ToString();
            if (wybor != null)
            {
                PoleNotatki.Text = File.ReadAllText(wybor.Trim());
            }

        }

        private void Nowa_Notatka(object sender, RoutedEventArgs e)
        {
            string nazwa = nazwa_notatki.Text;

            if (nazwa == "Wpisz Nazwę Notatki" || nazwa == null)
            {
                MessageBox.Show("Podaj nazwę notatki");
            }
            else if (notatki.Length == 0)
            {
                File.WriteAllLines(nazwa + ".txt", new string[0]);
                notatki = notatki.Append(nazwa + ".txt").ToArray();
                Odswiez_Notatki();
            }
            else
            {
                foreach (String notatka in notatki)
                {
                    if (System.IO.Path.GetFileName(notatka) == nazwa + ".txt")
                    {
                        MessageBox.Show("Notatka o takiej nazwie już istnieje");

                    }
                    else
                    {
                        File.WriteAllLines(nazwa + ".txt", new string[0]);
                        notatki = notatki.Append(nazwa + ".txt").ToArray();
                        Odswiez_Notatki();
                    }
                }

            }
        }

        private void Odswiez_Notatki()
        {
            // pobierz wszystkie notatki z folderu
            notatki = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

            foreach (String notatka in notatki)
            {
                if (ListaNotatek.Items.Contains(System.IO.Path.GetFileName(notatka)) == false)
                {
                    ListaNotatek.Items.Add(System.IO.Path.GetFileName(notatka));
                }
            }
        }
    }
}
