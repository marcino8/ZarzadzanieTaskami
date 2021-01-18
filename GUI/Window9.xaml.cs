using Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI
{
    /// <summary>
    /// Okno przydziału pracowników do projektu
    /// </summary>
    public partial class Window9 : Window
    {
        ObservableCollection<Uzytkownik> wybraniPracownicy;
        ObservableCollection<Uzytkownik> wszyscyPracownicy;
        Projekt projekt;
        public Window9(Projekt p)
        {
            projekt = p;
            InitializeComponent();
            BazaKont bk = BazaKont.Wczytaj_Baze();
            wszyscyPracownicy = new ObservableCollection<Uzytkownik>(bk.wybierzOsobyNieWProjekcie(new Pracownik(), projekt));
           
            wybraniPracownicy = new ObservableCollection<Uzytkownik>(projekt.ListaPracownikow);
            listboxPozostali.ItemsSource = wszyscyPracownicy;
            listBoxWProjekcie.ItemsSource = wybraniPracownicy;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (listboxPozostali.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)listboxPozostali.SelectedItem;
                wszyscyPracownicy.Remove(x);
                wybraniPracownicy.Add(x);
                projekt.ListaPracownikow.Add(x);
            }
        }

        private void usunButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxWProjekcie.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)listBoxWProjekcie.SelectedItem;
                wybraniPracownicy.Remove(x);
                wszyscyPracownicy.Add(x);
                projekt.usunPracownika(x);

            }
        }

        private void przydzielButton_Click(object sender, RoutedEventArgs e)
        {
            BazaProjektow b = BazaProjektow.Wczytaj_Baze();
            bool a = b.UsunZBazy(projekt);
            b.DodajDoBazy(projekt);
            b.Zapisz_Baze();
            MessageBox.Show("Pomyslnie zapisano zmiany");
        }
    }
}
