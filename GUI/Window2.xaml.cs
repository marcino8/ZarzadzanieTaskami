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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rejestracjaButton_Click(object sender, RoutedEventArgs e)
        {
            if (peselBox.Text != "" &&
                loginBox.Text != "" && 
                imieBox.Text != "" &&
                nazwiskoBox.Text != "" &&
                loginBox.Text != "" &&
                passwordBox.Password.ToString() != "" )
            {
                Uzytkownik u1 = new Pracownik();
                //public Uzytkownik(string imie, string nazwisko, int dd, int mm, int yyyy, string pesel, string email)
                if (listaCombo.Text == "Pracownik")
                {
                    u1 = new Pracownik(imieBox.Text, nazwiskoBox.Text, 
                       int.Parse(listaComboDzien.Text), int.Parse(listaComboMiesiac.Text), int.Parse(listaComboRok.Text),
                       peselBox.Text, emailBox.Text);
                }
                if (listaCombo.Text == "Sponsor")
                {
                    u1 = new Sponsor(imieBox.Text, nazwiskoBox.Text,
                     int.Parse(listaComboDzien.Text), int.Parse(listaComboMiesiac.Text), int.Parse(listaComboRok.Text),
                        peselBox.Text, emailBox.Text);
                }
                if (listaCombo.Text == "Manager")
                {
                    try
                    {
                        u1 = new Manager(imieBox.Text, nazwiskoBox.Text,
                    int.Parse(listaComboDzien.Text), int.Parse(listaComboMiesiac.Text), int.Parse(listaComboRok.Text),
                    peselBox.Text, emailBox.Text);
                    }
                    catch(NotAPeselException)
                    {
                        MessageBox.Show("Nieprawidłowy pesel!");
                    }
                    
                }

                Konto k1 = new Konto(u1, loginBox.Text, passwordBox.Password.ToString());
                BazaKont b = BazaKont.Wczytaj_Baze();
                b.DodajDoBazy(k1);
                b.Zapisz_Baze();
                
                DialogResult = true;
            }
            else
                DialogResult = false;
        }
    }
}
