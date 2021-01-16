using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Konto
    {
        Uzytkownik _uzytkownik;
        string _login;
        string _haslo;

        public string Login { get => _login; set => _login = value; }
        public string Haslo { get => _haslo; set => _haslo = value; }
        public Uzytkownik Uzytkownik { get => _uzytkownik; set => _uzytkownik = value; }
        public Konto()
        {

        }
        public Konto(Uzytkownik uzytkownik, string login, string haslo)
        {
            _uzytkownik = uzytkownik;
            _login = login;
            _haslo = haslo;
        }

        public override string ToString()
        {
            return $"login: {_login}\n"+_uzytkownik.ToString();
        }

    }
}
