using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// Klasa odpowiadająca komentarzom do zadania
    /// </summary>
    [Serializable]
    public class Uwaga
    {
        /// <summary>
        /// Tresc uwagi
        /// </summary>
        string _tresc;
        /// <summary>
        /// Uzytkownik zgłaszający uwagę
        /// </summary>
        Uzytkownik _zglaszajacy;

        public string Tresc { get => _tresc; set => _tresc = value; }
        public Uzytkownik Zglaszajacy { get => _zglaszajacy; set => _zglaszajacy = value; }

        public Uwaga()
        {
        }
        public Uwaga(string tresc, Uzytkownik zglaszajacy)
        {
            _tresc = tresc;
            _zglaszajacy = zglaszajacy;
        }
        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>Imie i nazwisko zgłaszającego uzytkownika i tresc uwagi</returns>
        public override string ToString()
        {
            return $"Zgłaszający: {_zglaszajacy.Imie} {_zglaszajacy.Nazwisko} Opis: {_tresc}";
        }
    }
}
