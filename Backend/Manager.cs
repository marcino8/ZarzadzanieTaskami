﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{    ///<summary>
     ///Typ użytkownika Manager
     ///</summary>
    [Serializable]
    public class Manager : Uzytkownik, IEquatable<Uzytkownik>
    {
        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>Informacje o użytkowniku
        /// <see cref="Uzytkownik.ToString()"/></returns>
        public override string ToString()
        {
            return base.ToString() + " MANAGER";
        }
        /// <summary>
        /// Sprawdza czy uzytkownicy są sobie równi
        /// </summary>
        /// <param name="other">Drugi uzytkownik</param>
        /// <returns>
        /// true - jeśli imie, nazwisko i pesel są takie same
        /// false - w przeciwnym wypadku
        /// <see cref="Uzytkownik._imie"/>
        /// <see cref="Uzytkownik._nazwisko"/>
        /// <see cref="Uzytkownik._pesel"/>
        /// </returns>
        public bool Equals(Uzytkownik other)
        {
            return this.Imie.Equals(other.Imie) && this.Nazwisko.Equals(other.Nazwisko) && this.Pesel.Equals(other.Pesel);
        }

        public Manager(string imie, string nazwisko, string dataUrodzenia, string pesel, string email) : base(imie, nazwisko, dataUrodzenia, pesel, email)
        {

        }
        public Manager()
        {

        }
        public Manager(string imie, string nazwisko, int dd, int mm, int yyyy, string pesel, string email) : base(imie, nazwisko, dd, mm, yyyy, pesel, email)
        {

        }
    }
}
