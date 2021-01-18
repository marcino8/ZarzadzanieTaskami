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
    /// Okno startowe, okno logowania
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// Metoda pokazuje okno rejestracji nowego konta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rejestracjaButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Window2();
            w.ShowDialog();
        }
        /// <summary>
        /// Metoda próbuje zalogować użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zalogujButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" &&
                passwordBox.Password != "")
            {
                //Sprawdz czy konto istnieje
                BazaKont b = BazaKont.Wczytaj_Baze();
                if (b.SprawdzKonto(loginBox.Text, passwordBox.Password))
                {
                    //zaloguj
                    this.Hide();
                    switch(b.SprawdzKto(loginBox.Text, passwordBox.Password))
                    {
                        case 1:
                            Window w1 = new Window4(b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password));
                            MessageBox.Show($"Zalogowano jako {b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password)}");
                            w1.Show();
                            break;
                        case 2:
                            Window w2 = new Window4(b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password));
                            MessageBox.Show($"Zalogowano jako {b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password)}");
                            w2.Show();
                            break;
                        case 3:
                            Window w3 = new Window3(b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password));
                            MessageBox.Show($"Zalogowano jako {b.wyciagnijUzytkownika(loginBox.Text, passwordBox.Password)}");
                            w3.Show();
                            break;
                        default:
                            MessageBox.Show("Cos poszlo nie tak");
                            break;
                    }
                        
                }
                else
                    MessageBox.Show("Niepoprawny login lub haslo");
            }
        }
    }
}
