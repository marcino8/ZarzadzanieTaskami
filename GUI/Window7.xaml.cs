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
    /// Logika interakcji dla klasy Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        Uzytkownik uzytkownik;
        Projekt projekt;
        ObservableCollection<Zadanie> aktualne;
        ObservableCollection<Zadanie> zakonczone;
        public Window7(Uzytkownik u, Projekt p)
        {
            projekt = p;
            uzytkownik = u;
            InitializeComponent();
            List<Zadanie> lista = projekt.zadaniaPracownika((Pracownik)u);
            aktualne = new ObservableCollection<Zadanie>(lista.Where(z => !z.Wykonane).ToList());
            zadaniaListBoxPrawy.ItemsSource = aktualne;
            zakonczone= new ObservableCollection<Zadanie>(lista.Where(z => z.Wykonane).ToList());
            zadaniaListBoxLewy.ItemsSource = zakonczone;
        }

        private void zakonczoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (zadaniaListBoxPrawy.SelectedIndex > -1)
            {
                Zadanie x = (Zadanie)zadaniaListBoxPrawy.SelectedItem;
                zakonczone.Add(x);
                aktualne.Remove(x);
                x.Wykonane = true;
            }
        }

        private void uwagaButton_Click(object sender, RoutedEventArgs e)
        {
            if (zadaniaListBoxPrawy.SelectedIndex > -1)
            {
                Zadanie x = (Zadanie)zadaniaListBoxLewy.SelectedItem;
                Window w1 = new Window12(x, uzytkownik);
                w1.ShowDialog();
            }
        }

        private void zadaniaListBoxPrawy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zmianyButton_Click(object sender, RoutedEventArgs e)
        {
            BazaProjektow b = BazaProjektow.Wczytaj_Baze();
            bool a = b.UsunZBazy(projekt);
            b.DodajDoBazy(projekt);
            b.Zapisz_Baze();
            MessageBox.Show("Pomyslnie zapisano zmiany");
        }
    }
}
