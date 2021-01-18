using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Backend
{
    ///<summary>
    ///Klasa przechowywująca konta użytkowników
    ///</summary>
    [Serializable]
    public class BazaKont
    {
        /// <summary>
        /// Przechowuje wszystkie konta
        /// </summary>
        List<Konto> lista_kont;
        public BazaKont()
        {
            this.lista_kont = new List<Konto>();
        }
        /// <summary>
        /// Metoda wczytywująca baze kont z pliku userbase.xml
        /// </summary>
        /// <returns>
        /// Zwraca wczytany obiekt klasy BazaKont
        /// </returns>
        public static BazaKont Wczytaj_Baze()
        {
            if (!File.Exists("userbase.xml"))
            {
                throw new FileNotFoundException();
            }
 
            BazaKont b = new BazaKont();
            XmlSerializer bf = new XmlSerializer(typeof(List<Konto>));
            using (StreamReader sr = new StreamReader("userbase.xml"))
            {
                b.lista_kont = (List<Konto>)(bf.Deserialize(sr));
            }
            return b;
        }
        /// <summary>
        /// Metoda zapisująca bazę użytkowników do pliku xml userbase.xml
        /// </summary>
        public void Zapisz_Baze()
        {

            XmlSerializer bf = new XmlSerializer(typeof(List<Konto>));
            using (StreamWriter sw = new StreamWriter("userbase.xml"))
            {
                bf.Serialize(sw, this.lista_kont);
            }

        }
        /// <summary>
        /// Metoda dodaje do bazy kont obiekt konto, nie samego uzytkownika
        /// </summary>
        /// <param name="k">
        /// Konto do dodania
        /// <see cref="Konto"/>
        /// </param>
        public void DodajDoBazy(Konto k)
        {
            lista_kont.Add(k);
        }
        /// <summary>
        /// Metoda usuwa z bazy konto
        /// </summary>
        /// <param name="k">
        /// Konto do usunięcia
        /// <see cref="Konto"/>
        /// </param>
        public void UsunZBazy(Konto k)
        {
            lista_kont.Remove(k);
        }
        /// <summary>
        /// Metoda sprawdza czy konto o podanym loginie i hasle znajduje się w bazie kont
        /// </summary>
        /// <param name="login">
        /// Login uzytkownika
        /// </param>
        /// <param name="password">
        /// Hasło użytkownika
        /// </param>
        /// <returns>
        /// true - jeśli konto znaleziono w bazie; 
        /// false - jeśli konta nie znaleziono w bazie
        /// </returns>
        public bool SprawdzKonto(string login, string password)
        {
            return lista_kont.Any(k => k.Login.Equals(login) && k.Haslo.Equals(password));
        }
        /// <summary>
        /// Metoda pozwalająca na wyszukanie i otrzymanie Uzytkownika przypisanego do konta z danym loginem i hasłem
        /// </summary>
        /// <param name="login">Login użytkownika</param>
        /// <param name="password">Hasło użytkownika</param>
        /// <returns>Obiekt klasy użytkownik, przypisany do konta z loginem login i hasłem password</returns>
        public Uzytkownik wyciagnijUzytkownika(string login, string password)
        {
            if(SprawdzKonto(login, password))
            {
                return lista_kont.First(k => k.Login.Equals(login) && k.Haslo.Equals(password)).Uzytkownik;
            }
            return null;
        }

        /// <summary>
        /// Metoda wybierająca wszystkie konta, gdzie użytkownik jest danego typu
        /// </summary>
        /// <param name="u">Przykładowy typ użytkownika(Sponsor/Pracownik/Manager)</param>
        /// <returns>Lista kont których właściciele są tego samego typu co u</returns>
        public List<Konto> wybierzKonta(Uzytkownik u)
        {
            return lista_kont.Where(k => k.Uzytkownik.GetType().Equals(u.GetType())).ToList();
        }
        /// <summary>
        /// Metoda wybierająca wszystkich użytkowników z bazy kont, gdzie użytkownik jest danego typu
        /// </summary>
        /// <param name="u">Przykładowy typ użytkownika(Sponsor/Pracownik/Manager)</param>
        /// <returns>Lista użytkowników których właściciele są tego samego typu co u</returns>
        public List<Uzytkownik> wybierzOsoby(Uzytkownik u)
        {
            List<Uzytkownik> list = new List<Uzytkownik>();
            foreach (Konto k in lista_kont)
            {
                if (k.Uzytkownik.GetType().Equals(u.GetType()))
                    list.Add(k.Uzytkownik);
            }
            return list;
        }
        /// <summary>
        /// Metoda wybierająca wszystkich użytkowników z bazy kont, gdzie użytkownik nie jest członkiem danego projektu
        /// </summary>
        /// <param name="u">Przykładowy typ użytkownika(Sponsor/Pracownik/Manager)</param>
        /// <param name="p">Projekt w którym mają nie uczestniczyć użytkownicy</param>
        /// <returns>Listę użytkowników, którzy są w bazie kont, ale nie są w projekcie jako wykonawcy
        /// <see cref="Projekt.listaPracownikow"/>
        /// </returns>
        public List<Uzytkownik> wybierzOsobyNieWProjekcie(Uzytkownik u, Projekt p)
        {
            List<Uzytkownik> list = new List<Uzytkownik>();
            
            foreach (Konto k in lista_kont)
            {
                if (k.Uzytkownik.GetType().Equals(u.GetType()))
                {
                    Console.WriteLine("TU WCHODZI");
                    if (!p.maPracownika((Pracownik)k.Uzytkownik))
                    {
                        list.Add(k.Uzytkownik);
                        Console.WriteLine("A TU?");
                    }
                }
                    
            }
            return list;
        }
        /// <summary>
        /// Sprawdza typ użytkownika skojarzony z danym loginem i hasłem konta
        /// </summary>
        /// <param name="login">Login do konta</param>
        /// <param name="haslo">Hasło do konta</param>
        /// <returns>Użytkownik w koncie, które skojarzono z podanym loginem i hasłem</returns>
         public int SprawdzKto(string login, string haslo)
        {
            if (SprawdzKonto(login, haslo))
            {
                Uzytkownik u = lista_kont.First(k => k.Login.Equals(login) && k.Haslo.Equals(haslo)).Uzytkownik;
                if (u is Pracownik)
                    return 1; //Pracownik
                if (u is Sponsor)
                    return 2; //Sponsor
                else
                    return 3; //Manager
            }
            return -1;
        }
    }
}
