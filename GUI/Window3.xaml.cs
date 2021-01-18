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
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Uzytkownik uzytkownik;
        public Window3(Uzytkownik u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void nowyButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Window5(uzytkownik);
            this.Close();
            w.Show();
        }

        private void aktualneButton_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Window4(uzytkownik);
            this.Close();
            w1.Show();
        }

        private void archiwumButton_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Window8();
            w1.ShowDialog();
        }
    }
}
