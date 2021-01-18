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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Panel zarządzania Managera
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
            this.Close();
            Window w1 = new Window8(uzytkownik);
            w1.ShowDialog();
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
