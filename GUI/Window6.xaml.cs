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
    /// Okno edycji projektu/zarządzania projektem
    /// </summary>
    public partial class Window6 : Window
    {
        Uzytkownik uzytkownik;
        Projekt projekt;
        ObservableCollection<Zadanie> zadania_nieprzydzielone;
        ObservableCollection<Zadanie> zadania_przydzielone;
        ObservableCollection<Zadanie> zadania_zakonczone;


        public Window6(Uzytkownik u, Projekt p)
        {
            InitializeComponent();
            uzytkownik = u;
            projekt = p;
            zadania_nieprzydzielone = new ObservableCollection<Zadanie>(projekt.wybierzNieprzydzielone());
            zadania_przydzielone = new ObservableCollection<Zadanie>(projekt.wybierzPrzydzielone());
            zadania_zakonczone = new ObservableCollection<Zadanie>(projekt.wybierzZakonczone());
            przydzieloneListBox.ItemsSource = zadania_przydzielone;
            noweListBox.ItemsSource = zadania_nieprzydzielone;
        }

        private void przydzieloneListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zakonczoneButton_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Window11(new List<Zadanie>(zadania_zakonczone), uzytkownik);
            w1.ShowDialog();
        }

        private void pracownicyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window w1 = new Window9(projekt);
            w1.ShowDialog();
            Window w2 = new Window6(uzytkownik, projekt);
            w2.Show();
        }

        private void przydzielButton_Click(object sender, RoutedEventArgs e)
        {
            if (noweListBox.SelectedIndex > -1)
            {
                Zadanie x = (Zadanie)noweListBox.SelectedItem;
                Window w1 = new Window10(projekt, x);
                w1.ShowDialog();
                if (w1.DialogResult.HasValue)
                {
                    if (w1.DialogResult.Value)
                    {
                        zadania_nieprzydzielone.Remove(x);
                        zadania_przydzielone.Add(x);
                    }
                }
                BazaProjektow b = BazaProjektow.Wczytaj_Baze();
                b.UsunZBazy(projekt);
                b.DodajDoBazy(projekt);

            }
        }

        private void uwagaButton_Click(object sender, RoutedEventArgs e)
        {
            Zadanie z = new Zadanie();
            Window w = new Window13(z);
            w.ShowDialog();
            if (w.DialogResult.HasValue)
            {
                if (w.DialogResult.Value)
                {
                    projekt.ListaZadan.Add(z);
                    zadania_nieprzydzielone.Add(z);
                }
            }
        }

        private void uwagiButton_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Window11(projekt.listaZadan, uzytkownik);
            w1.Show();
        }

        private void zadanieUsunClick(object sender, RoutedEventArgs e)
        {
            Zadanie x = (Zadanie)noweListBox.SelectedItem;
            if (noweListBox.SelectedIndex > -1)
            {
                projekt.ListaZadan.Remove(x);
                zadania_nieprzydzielone.Remove(x);
                projekt.usunZadanie(x);
            }
        }

        private void sortujButton_Click(object sender, RoutedEventArgs e)
        {
            List<Zadanie> list = new List<Zadanie>(zadania_nieprzydzielone);
            list.Sort();
            zadania_nieprzydzielone = new ObservableCollection<Zadanie>(list);
        }

        private void sortujButton2_Click(object sender, RoutedEventArgs e)
        {
            List<Zadanie> list = new List<Zadanie>(zadania_przydzielone);
            list.Sort();
            zadania_przydzielone = new ObservableCollection<Zadanie>(list);
        }

        private void zapiszjButton2_Click(object sender, RoutedEventArgs e)
        {
            BazaProjektow b = BazaProjektow.Wczytaj_Baze();
            bool a=b.UsunZBazy(projekt);
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
