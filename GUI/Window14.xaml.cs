using Backend;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy Window14.xaml
    /// </summary>
    public partial class Window14 : Window
    {
        Zadanie zadanie;
        Uzytkownik uzytkownik;
        public Window14(Zadanie z, Uzytkownik u)
        {
            zadanie = z;
            uzytkownik = u;
            InitializeComponent();
        }

        private void dodajUwageBTn_Click(object sender, RoutedEventArgs e)
        {
            if (komentarzBox.Text != "")
            {
                zadanie.Uwagi.Add(new Uwaga(komentarzBox.Text, uzytkownik));
                DialogResult = true;
            }
        }
    }
}
