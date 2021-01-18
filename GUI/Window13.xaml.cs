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
    /// Logika interakcji dla klasy Window13.xaml
    /// </summary>
    public partial class Window13 : Window
    {
        Zadanie zadanie;
        public Window13(Zadanie z)
        {
            zadanie = z;
            InitializeComponent();
        }


        private void zatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            //SPRAWDZ DATE
            if (tematBox.Text != "" && trescBox.Text != "")
            {
                zadanie.CzasRozpoczecia = DateTime.Now;
                DateTime data= new DateTime(int.Parse(listaComboRok.Text), int.Parse(listaComboMiesiac.Text), int.Parse(listaComboDzien.Text));
                if (zadanie.CzasRozpoczecia.CompareTo(data) > 0)
                {
                    MessageBox.Show("Nieprawidłowa data zakończenia");
                    DialogResult = false;
                }


                zadanie.Temat = tematBox.Text;
                zadanie.Tresc = trescBox.Text;
                switch (listaCombo.Text)
                {
                    case "Mało istotne":
                        zadanie.WaznoscZadania = Enumy.WaznoscZadania.Mało_istotne;
                        break;
                    case "Istotne":
                        zadanie.WaznoscZadania = Enumy.WaznoscZadania.Istotne;
                        break;
                    case "Ważne":
                        zadanie.WaznoscZadania = Enumy.WaznoscZadania.Ważne;
                        break;
                    case "Krytycznie ważne":
                        zadanie.WaznoscZadania = Enumy.WaznoscZadania.Krytycznie_ważne;
                        break;
                    default:
                        zadanie.WaznoscZadania = Enumy.WaznoscZadania.Istotne;
                        break;
                }
                DialogResult = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void anulujButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
