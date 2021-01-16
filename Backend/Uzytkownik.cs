using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    [Serializable]
    [XmlInclude(typeof(Sponsor))]
    [XmlInclude(typeof(Pracownik))]
    [XmlInclude(typeof(Manager))]
    public class Uzytkownik 
    {
        string _imie;
        string _nazwisko;
        DateTime _dataUrodzenia;
        string _pesel;
        string _email;

        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }
        public string Pesel { get => _pesel; set => _pesel = value; }
        public string Email { get => _email; set => _email = value; }

        public Uzytkownik()
        {
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

        public override string ToString()
        {
            return $"{_imie} {_nazwisko}, data urodzenia: {_dataUrodzenia.ToShortDateString()} " +
                $"pesel: {_pesel}, email: {_email}";
        }

        public string toShortString()
        {
            return $"{_imie} {_nazwisko}";
        }

    }
}
