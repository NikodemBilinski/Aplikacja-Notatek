using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
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

        private ObservableCollection<string> notatki = new ObservableCollection<string>();
        public Okno_Notatki()
        {
            InitializeComponent();

            ListaNotatek.ItemsSource = notatki;
        }
        private void Zapisz_Notatke(object sender, RoutedEventArgs e)
        {
            
            string Tekst_Notatki = PoleNotatki.Text;

            File.WriteAllText("Notatka" + counternotatki + ".txt", Tekst_Notatki);

            notatki.Add("Notatka" + counternotatki + ".txt");
            counternotatki++;

            MessageBox.Show("Notatka została zapisana!");
        }

        private void Powrot_Menu_Glowne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Wybor_Notatki(object sender, SelectionChangedEventArgs e)
        {
            if(ListaNotatek.SelectedItem != null)
            {
                string wybranaNotatka = ListaNotatek.SelectedItem.ToString();

                Console.Write(wybranaNotatka);
                string plik = wybranaNotatka;  
                if(File.Exists(plik))
                {
                    string tekstNotatki = File.ReadAllText(plik);
                    PoleNotatki.Text = tekstNotatki;
                }
            }
        }
    }
}
