using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    /// <summary>
    /// Klasa bazowa dla uzytkownika, opisuje wszystkie cechy łączące Sponsora Pracownika i Managera
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Sponsor))]
    [XmlInclude(typeof(Pracownik))]
    [XmlInclude(typeof(Manager))]
    public abstract class Uzytkownik
    {
        /// <summary>
        /// Imie uzytkownika
        /// </summary>
        string _imie;
        /// <summary>
        /// Nazwisko uzytkownika
        /// </summary>
        string _nazwisko;
        /// <summary>
        /// Data urodzenia uzytkownika
        /// </summary>
        DateTime _dataUrodzenia;
        /// <summary>
        /// Pesel uzytkownika
        /// </summary>
        string _pesel;
        /// <summary>
        /// Email uzytkownika
        /// </summary>
        string _email;

        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }
        public string Pesel { get => _pesel; set => _pesel = value; }
        public string Email { get => _email; set => _email = value; }

        public Uzytkownik()
        {
        }
        public Uzytkownik(string imie, string nazwisko,int dd, int mm, int yyyy, string pesel, string email)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _dataUrodzenia = new DateTime(yyyy, mm, dd);
            if (pesel.Length != 11)
            {
                throw new NotAPeselException();
            }
            _pesel = pesel;
            _email = email;
        }
        public Uzytkownik(string imie, string nazwisko, string dataUrodzenia, string pesel, string email)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            DateTime.TryParseExact(dataUrodzenia, new[] { 
                "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy", "dd.MM.yyyy", "dd-MM-yyyy" }
            , null, DateTimeStyles.None, out this._dataUrodzenia);
            if (pesel.Length != 11)
            {
                throw new NotAPeselException();
            }
            _pesel = pesel;
            _email = email;
        }
        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>Zwraca pełne informacje o uzytkowniku</returns>
        public override string ToString()
        {
            return $"{_imie} {_nazwisko}, data urodzenia: {_dataUrodzenia.ToShortDateString()} " +
                $"pesel: {_pesel}, email: {_email}";
        }
        /// <summary>
        /// Metoda wypisuje imie i nazwisko uzytkownika
        /// </summary>
        /// <returns>Imie i nazwisko uzytkownika</returns>
        public string toShortString()
        {
            return $"{_imie} {_nazwisko}";
        }

    }
}
