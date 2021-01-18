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
    /// Logika interakcji dla klasy Window11.xaml
    /// </summary>
    public partial class Window11 : Window
    {
        ObservableCollection<Zadanie> listaZadan;
        Uzytkownik uzytkownik;
        public Window11(List<Zadanie> list, Uzytkownik u)
        {
            InitializeComponent();
            uzytkownik = u;
            listaZadan = new ObservableCollection<Zadanie>(list);
            zadaniaListBoxLewy.ItemsSource = listaZadan;

        }

        private void zadaniaListBoxLewy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wyswietlButton_Click(object sender, RoutedEventArgs e)
        {
            if (zadaniaListBoxLewy.SelectedIndex > -1)
            {
                Zadanie x = (Zadanie)zadaniaListBoxLewy.SelectedItem;
                Window w1 = new Window12(x,uzytkownik);
                w1.ShowDialog();

            }
        }
    }
}
