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
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        Uzytkownik uzytkownik;
        ObservableCollection<Projekt> lista;
        public Window4(Uzytkownik u)
        {
            uzytkownik = u;
            InitializeComponent();
            if (u.GetType().Equals(new Pracownik().GetType()))
                archiwizujButton.Visibility = Visibility.Hidden;
            BazaProjektow bp = BazaProjektow.Wczytaj_Baze();
            lista = new ObservableCollection<Projekt>(bp.wyszukajProjekty(u));   
            projektyListBox.ItemsSource = lista;
        }

        private void potwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (projektyListBox.SelectedIndex > -1)
            {
                Projekt x = (Projekt)projektyListBox.SelectedItem;
                this.Hide();
                if(uzytkownik is Sponsor || uzytkownik is Pracownik)
                {
                    Window w1 = new Window7(uzytkownik, x);
                    w1.Show();
                }
                if(uzytkownik is Manager)
                {
                    Window w1 = new Window6(uzytkownik, x);
                    w1.Show();
                }
                
            }
        }

        private void archiwizujButton_Click(object sender, RoutedEventArgs e)
        {
            if (projektyListBox.SelectedIndex > -1)
            {
                Projekt x = (Projekt)projektyListBox.SelectedItem;
                BazaProjektow b=BazaProjektow.Wczytaj_Baze();
                b.UsunZBazy(x);
                lista.Remove(x);
                b.Zapisz_Baze();
                ArchiwumProjektow a = ArchiwumProjektow.WczytajArchiwum();
                a.DodajDoArchiwum(x);
                a.ZapiszArchiwum();
            }
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
