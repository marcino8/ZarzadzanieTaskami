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
    /// Logika interakcji dla klasy Window10.xaml
    /// </summary>
    public partial class Window10 : Window
    {
        ObservableCollection<Uzytkownik> wybraniPracownicy;
        Projekt projekt;
        Zadanie z;
        public Window10(Projekt p, Zadanie z)
        {

            InitializeComponent();
            this.z = z;
            projekt = p;
            wybraniPracownicy = new ObservableCollection<Uzytkownik>(projekt.ListaPracownikow);
            pracownicyLisBox.ItemsSource = wybraniPracownicy;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pracownicyLisBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pracownicyLisBox.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)pracownicyLisBox.SelectedItem;
                ZadaniaPracownikaLisBox.ItemsSource = new ObservableCollection<Zadanie>(projekt.zadaniaPracownika(x));
            }
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (pracownicyLisBox.SelectedIndex > -1)
            {
                Pracownik x = (Pracownik)pracownicyLisBox.SelectedItem;
                z.Wykonawcy.Add(x);
                DialogResult = true;
            }
        }
    }
}
