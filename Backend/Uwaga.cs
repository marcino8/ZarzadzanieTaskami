using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Uwaga
    {
        string _tresc;
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

        public override string ToString()
        {
            return $"Zgłaszający: {_zglaszajacy.Imie} {_zglaszajacy.Nazwisko}";
        }
    }
}
