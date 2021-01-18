using Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
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
    /// Logika interakcji dla klasy Window12.xaml
    /// </summary>
    public partial class Window12 : Window
    {
        Zadanie zadanie;
        Uzytkownik uzytkownik;
        ObservableCollection<Uwaga> uwagi;
        public Window12(Zadanie z, Uzytkownik u)
        {
            uzytkownik = u;
            zadanie = z;
            InitializeComponent();
            zadanieBox.Text = zadanie.Temat;
            komentarzBox.Text = zadanie.Tresc;
            uwagi= new ObservableCollection<Uwaga>(zadanie.Uwagi);
            uwagiListBox.ItemsSource = uwagi;
        }

        private void zatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (zadanieBox.Text != "" && komentarzBox.Text != "")
            {
                zadanie.Temat = zadanieBox.Text;
                zadanie.Tresc = komentarzBox.Text;
                DialogResult = true;
            }              
        }

        private void dodajUwageBTn_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Window14(zadanie,uzytkownik);
            w1.ShowDialog();
            uwagi = new ObservableCollection<Uwaga>(zadanie.Uwagi);
            uwagiListBox.ItemsSource = uwagi;
            BazaProjektow bl = BazaProjektow.Wczytaj_Baze();
        }

        private void usunUwageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (uwagiListBox.SelectedIndex > -1)
            {
                Uwaga x = (Uwaga)uwagiListBox.SelectedItem;
                zadanie.Uwagi.Remove(x);
                uwagi.Remove(x);
            }
        }
    }
}
