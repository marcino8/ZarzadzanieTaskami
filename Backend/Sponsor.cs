using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Sponsor : Uzytkownik, IEquatable<Uzytkownik>
    {
        public override string ToString()
        {
            return base.ToString()+ " SPONSOR";
        }

        public bool Equals(Uzytkownik other)
        {
            return this.Imie.Equals(other.Imie) && this.Nazwisko.Equals(other.Nazwisko) && this.Pesel.Equals(other.Pesel);
        }

        public Sponsor()
        {

        }
        public Sponsor(string imie, string nazwisko, string dataUrodzenia, string pesel, string email) : base(imie, nazwisko, dataUrodzenia, pesel, email)
        {

        }
        public Sponsor(string imie, string nazwisko, int dd, int mm, int yyyy, string pesel, string email) : base(imie, nazwisko, dd, mm, yyyy, pesel, email)
        {

        }

    }
}
