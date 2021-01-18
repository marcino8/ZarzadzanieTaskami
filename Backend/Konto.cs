using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    ///<summary>
    ///Klasa zawierająca login hasło i użytkownika, wykorzystywana w systemie logowania do rozpoznawania użytkowników
    ///</summary>
    [Serializable]
    public class Konto
    {
        /// <summary>
        /// Użytkownik danego konta
        /// </summary>
        Uzytkownik _uzytkownik;
        /// <summary>
        /// Login danego konta
        /// </summary>
        string _login;

        /// <summary>
        /// Hasło danego konta
        /// </summary>
        string _haslo;

        public string Login { get => _login; set => _login = value; }
        public string Haslo { get => _haslo; set => _haslo = value; }
        public Uzytkownik Uzytkownik { get => _uzytkownik; set => _uzytkownik = value; }
        public Konto()
        {

        }
        /// <summary>
        /// Metoda tworząca obiekt klasy Konto
        /// </summary>
        /// <param name="uzytkownik">Użytkownik</param>
        /// <param name="login">login</param>
        /// <param name="haslo">hasło</param>
        public Konto(Uzytkownik uzytkownik, string login, string haslo)
        {
            _uzytkownik = uzytkownik;
            _login = login;
            _haslo = haslo;
        }
        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>
        /// Zwraca login danego użytkownika i informacje o użytkowniku
        /// <see cref="Uzytkownik.ToString()"/>
        /// </returns>
        public override string ToString()
        {
            return $"login: {_login}\n"+_uzytkownik.ToString();
        }

    }
}
