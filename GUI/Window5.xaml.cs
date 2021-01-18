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
    /// Logika interakcji dla klasy Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        Uzytkownik uzytkownik;
        ObservableCollection<Uzytkownik> wszyscyPracownicy;
        ObservableCollection<Zadanie> zadania;
        ObservableCollection<Uzytkownik> wszyscySponsorzy;
        ObservableCollection<Uzytkownik> wybraniPracownicy;
        ObservableCollection<Uzytkownik> wybraniSponsorzy;
        public Window5(Uzytkownik u)
        {
            uzytkownik = u;
            InitializeComponent();
            BazaKont bk = BazaKont.Wczytaj_Baze();
            wszyscyPracownicy = new ObservableCollection<Uzytkownik>(bk.wybierzOsoby(new Pracownik()));
            wszyscySponsorzy = new ObservableCollection<Uzytkownik>(bk.wybierzOsoby(new Sponsor()));
            MessageBox.Show($"{ bk.wybierzOsoby(u).Count() }{u.toShortString()}");
            wybraniPracownicy = new ObservableCollection<Uzytkownik>();
            wybraniSponsorzy = new ObservableCollection<Uzytkownik>();
            zadania = new ObservableCollection<Zadanie>();
            zadaniaListBox.ItemsSource = zadania;
            pracownicyListBox.ItemsSource = wszyscyPracownicy;
            sponsorzyListBox.ItemsSource = wszyscySponsorzy;
            pracownicyWybraniListBox.ItemsSource = wybraniPracownicy;
            sponsorzyWybraniListBox.ItemsSource = wybraniSponsorzy;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pracownicyListBox.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)pracownicyListBox.SelectedItem;
                wszyscyPracownicy.Remove(x);
                wybraniPracownicy.Add(x);
            }
        }

        private void sponsorzyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void usunPracownikaButton_Click(object sender, RoutedEventArgs e)
        {
            if (pracownicyWybraniListBox.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)pracownicyWybraniListBox.SelectedItem;
                wszyscyPracownicy.Add(x);
                wybraniPracownicy.Remove(x);
            }
        }

        private void pracownicyWybraniListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodajSponsoraButton_Click(object sender, RoutedEventArgs e)
        {
            if (sponsorzyListBox.SelectedIndex > -1)
            {
                Sponsor x = (Sponsor)sponsorzyListBox.SelectedItem;
                wszyscySponsorzy.Remove(x);
                wybraniSponsorzy.Add(x);
            }
        }

        private void usunSponsoraButton_Click(object sender, RoutedEventArgs e)
        {
            if (sponsorzyWybraniListBox.SelectedIndex > -1)
            {
                Sponsor x = (Sponsor)sponsorzyWybraniListBox.SelectedItem;
                wszyscySponsorzy.Add(x);
                wybraniSponsorzy.Remove(x);
            }
        }

        private void dodajZadanieButton_Click(object sender, RoutedEventArgs e)
        {
            Zadanie z = new Zadanie();
            Window w = new Window13(z);
            w.ShowDialog();
            MessageBox.Show("a");
            if (w.DialogResult.HasValue)
            {
                if (w.DialogResult.Value)
                {
                    zadania.Add(z);
                }
            }
        }

        private void usunZadanieButton_Click(object sender, RoutedEventArgs e)
        {
            if (zadaniaListBox.SelectedIndex > -1)
            {
                Zadanie x = (Zadanie)zadaniaListBox.SelectedItem;
                zadania.Remove(x);
            }
        }

        private void utworzProjektbutton_Click(object sender, RoutedEventArgs e)
        {
            List<Pracownik> pracownicy = new List<Pracownik>();
            List<Sponsor> sponsorzy = new List<Sponsor>();
            foreach (Uzytkownik p in wybraniPracownicy)
            {
                pracownicy.Add((Pracownik)p);
            }
            foreach (Uzytkownik s in wybraniSponsorzy)
            {
                sponsorzy.Add((Sponsor)s);
            }
            if (nazwaBox.Text != "" && opisBox.Text != "")
            {
                Projekt p = new Projekt(nazwaBox.Text, opisBox.Text, (Manager)uzytkownik,
                     new List<Zadanie>(zadania), new List<Zadanie>(), pracownicy, sponsorzy);
                BazaProjektow bp = BazaProjektow.Wczytaj_Baze();
                bp.DodajDoBazy(p);
                bp.Zapisz_Baze();
                Window w1 = new Window6(uzytkownik, p);
                this.Close();
                w1.Show();
            }
            
        } // public Projekt(string nazwa, string opis, Manager manager,
        //List<Zadanie> listaZadan, List<Zadanie> wykonaneZadania, List<Pracownik> listaPracownikow, List<Sponsor> listaSponsorow)
    }
}
