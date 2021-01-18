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
    /// Okno archium projektow
    /// </summary>
    public partial class Window8 : Window
    {
        ObservableCollection<Projekt> archiwum;
        Uzytkownik uzytkownik;
        public Window8(Uzytkownik u)
        {
            uzytkownik = u;
            InitializeComponent();
            ArchiwumProjektow a1 = ArchiwumProjektow.WczytajArchiwum();
            archiwum = new ObservableCollection<Projekt>(a1.ZakonczoneProjekty);
            projektyListBox.ItemsSource = archiwum;
        }

        private void projektyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PrzeniesDoBazy_Click(object sender, RoutedEventArgs e)
        {
            BazaProjektow bp = BazaProjektow.Wczytaj_Baze();
            ArchiwumProjektow archiwumProjektow = ArchiwumProjektow.WczytajArchiwum();
            if (projektyListBox.SelectedIndex > -1)
            {
                Projekt x = (Projekt)projektyListBox.SelectedItem;
                archiwum.Remove(x);
                bp.DodajDoBazy(x);
                archiwumProjektow.UsunTrwale(x);
                bp.Zapisz_Baze();
                archiwumProjektow.ZapiszArchiwum();
            }
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            Window w3 = new Window3(uzytkownik);
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
