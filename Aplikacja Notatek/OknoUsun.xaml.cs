using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy OknoUsun.xaml
    /// </summary>
    public partial class OknoUsun : Window
    {

        private string[] notatki = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

        public OknoUsun()
        {
            InitializeComponent();
            Odswiez_Notatki();
        }


        private void Odswiez_Notatki()
        {
            // pobierz wszystkie notatki z folderu
            notatki = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

            foreach (String notatka in notatki)
            {
                if (ListaNotatek_Usun.Items.Contains(System.IO.Path.GetFileName(notatka)) == false)
                {
                    ListaNotatek_Usun.Items.Add(System.IO.Path.GetFileName(notatka));
                }
            }
        }

        private void Usun_Notatke(object sender, RoutedEventArgs e)
        {
            string wybor = ListaNotatek_Usun.SelectedItem.ToString();
            if (wybor != null)
            {
                File.Delete(wybor.Trim());
                ListaNotatek_Usun.Items.Clear();
                Odswiez_Notatki();
            }
        }

        private void Powrot(object sender, RoutedEventArgs e)
        {
            this.Close();
            var oknoNotatki = new Okno_Notatki();
            oknoNotatki.Show();
        }
    }
}
