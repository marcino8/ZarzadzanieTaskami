using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    abstract class Uzytkownik
    {
        string _imie;
        string _nazwisko;
        DateTime _dataUrodzenia;
        string _pesel;

        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }
        public string Pesel { get => _pesel; set => _pesel = value; }

        public Uzytkownik()
        {
        }

        public Uzytkownik(string imie, string nazwisko, DateTime dataUrodzenia, string pesel)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _dataUrodzenia = dataUrodzenia;
            _pesel = pesel;
        }
    }
}
