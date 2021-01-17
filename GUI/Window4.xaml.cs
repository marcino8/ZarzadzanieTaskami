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
            BazaProjektow bp = BazaProjektow.Wczytaj_Baze();
            lista = new ObservableCollection<Projekt>(bp.wyszukajProjekty(u));
            MessageBox.Show($"{ bp.wyszukajProjekty(u).Count() }{u.toShortString()}");
            
            projektyListBox.ItemsSource = lista;
        }

        private void potwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (projektyListBox.SelectedIndex > -1)
            {
                Projekt x = (Projekt)projektyListBox.SelectedItem;
                this.Hide();
                Window w1 = new Window7(uzytkownik, x);
                w1.Show();
            }
        }
    }
}
