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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Panel użytkownika i sponsora
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
            System.Windows.MessageBox.Show("Pomyslnie zapisano zmiany");
        }

        private void wyloguj(object sender, RoutedEventArgs e)
        {
            DialogResult d = System.Windows.Forms.MessageBox.Show("Czy chcesz wyjść? Niezapisane zmiany zostaną utracone", "Ostrzeżenie!", MessageBoxButtons.YesNo);

            if (d.Equals(System.Windows.Forms.DialogResult.Yes))
            {
                this.Close();
                Window w1 = new Window1();
                w1.Show();
            }
            else if (d.Equals(System.Windows.Forms.DialogResult.Yes))
            {
                ;
            }
        }
    }
}
