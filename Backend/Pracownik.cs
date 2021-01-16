using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Pracownik : Uzytkownik
    {
        public override string ToString()
        {
            return base.ToString() + " PRACOWNIK";
        }
        public Pracownik(string imie, string nazwisko, string dataUrodzenia, string pesel, string email) : base(imie, nazwisko, dataUrodzenia, pesel, email)
        {
            
        }
    }
}
