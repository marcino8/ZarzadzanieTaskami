using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Uwaga
    {
        string _tresc;
        Uzytkownik _zglaszajacy;

        public string Tresc { get => _tresc; set => _tresc = value; }
        public Uzytkownik Zglaszajacy { get => _zglaszajacy; set => _zglaszajacy = value; }
    }
}
