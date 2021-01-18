using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    ///<summary>
    ///Klasa przechowywująca dane dotyczące projektu
    /// </summary>
    [Serializable]
    public class Projekt : ICloneable, IEquatable<Projekt>
    {
        /// <summary>
        /// Nazwa projektu
        /// </summary>
        string nazwa;
        /// <summary>
        /// Opis projektu
        /// </summary>
        string opis;
        /// <summary>
        /// Manager zarządzający projektem
        /// </summary>
        Manager manager;
        /// <summary>
        /// Lista zadań do wykonania w projekcie
        /// </summary>
        public List<Zadanie> listaZadan;
        /// <summary>
        /// Lista zadań wykonanych już w projekcie
        /// </summary>
        public List<Zadanie> wykonaneZadania;
        /// <summary>
        /// Lista pracowników uczestniczących w projekcie
        /// </summary>
        public List<Pracownik> listaPracownikow;
        /// <summary>
        /// Lista sponsorów sponsorujących projekt
        /// </summary>
        public List<Sponsor> listaSponsorow;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Opis { get => opis; set => opis = value; }
        public Manager Manager { get => manager; set => manager = value; }
        public List<Zadanie> ListaZadan { get => listaZadan; set => listaZadan = value; }
        public List<Zadanie> WykonaneZadania { get => wykonaneZadania; set => wykonaneZadania = value; }
        public List<Pracownik> ListaPracownikow { get => listaPracownikow; set => listaPracownikow = value; }
        public List<Sponsor> ListaSponsorow { get => listaSponsorow; set => listaSponsorow = value; }

        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>
        /// Informacje o projeckie:
        /// Managera, temat, oraz treści i tematy zadań
        /// <see cref="Projekt.manager"/>
        /// <see cref="Projekt.nazwa"/>
        /// <see cref="Projekt.listaZadan"/>
        /// <see cref="Zadanie._tresc"/>
        /// <see cref="Zadanie.Temat"/>
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var x in ListaZadan)
            {
                sb.Append(x.ToString());
            }

            return $"Temat: {nazwa}, " +
                $"Manager: {manager.toShortString()}";
 
        }

        public Projekt(string nazwa, string opis, Manager manager, List<Zadanie> listaZadan, List<Zadanie> wykonaneZadania, List<Pracownik> listaPracownikow, List<Sponsor> listaSponsorow) : this(nazwa, opis, manager)
        {
            this.listaZadan = listaZadan;
            this.wykonaneZadania = wykonaneZadania;
            this.listaPracownikow = listaPracownikow;
            this.listaSponsorow = listaSponsorow;
        }

        public Projekt()
        {
            this.listaZadan = new List<Zadanie>();
            this.wykonaneZadania = new List<Zadanie>();
            this.listaPracownikow = new List<Pracownik>();
            this.listaSponsorow = new List<Sponsor>();
        }

        public Projekt(Manager manager):this()
        {
            this.manager = manager;
        }

        public Projekt(string nazwa, string opis, Manager manager) : this(manager)
        {
            this.nazwa = nazwa;
            this.opis = opis;
        }
        /// <summary>
        /// Metoda dodaje zadanie do projektu
        /// </summary>
        /// <param name="z">Zadanie do dodania</param>
        public void dodajZadanie(Zadanie z)
        {
            listaZadan.Add(z);
        }
        /// <summary>
        /// Metoda usuwa zadanie z projektu
        /// </summary>
        /// <param name="z">Zadanie do usunięcia</param>
        public void usunZadanie(Zadanie z)
        {
            listaZadan.Remove(z);
        }
        /// <summary>
        /// Metoda dodaje pracownika do projektu
        /// </summary>
        /// <param name="p">Pracownik do dodania</param>
        public void dodajPracownika(Pracownik p )
        {
            listaPracownikow.Add(p);
        }
        /// <summary>
        /// Metoda dodaje pracowników do projektu
        /// </summary>
        /// <param name="p">Lista pracowników</param>
        public void dodajPracownikow(List<Pracownik> p)
        {
            foreach(var x in p)
            {
                listaPracownikow.Add(x);
            }

        }
        /// <summary>
        /// Metoda usuwa pracownika z projektu
        /// </summary>
        /// <param name="p">Pracownik do usunięcia</param>
        public void usunPracownika(Pracownik p)
        {
            foreach(Zadanie z in this.zadaniaPracownika(p))
            {
                z.Wykonawcy.Remove(p);
            }
            listaPracownikow.Remove(p);
        }
        /// <summary>
        /// Metoda dodaje sponsora do projektu
        /// </summary>
        /// <param name="s">Sponsor do dodania</param>
        public void dodajSponsora(Sponsor s)
        {
            listaSponsorow.Add(s);
        }
        /// <summary>
        /// Metoda dodaje sponsorów do projektu
        /// </summary>
        /// <param name="p">Lista sponsorów</param>
        public void dodajSponsorow(List<Sponsor> p)
        {
            foreach (var x in p)
            {
                listaSponsorow.Add(x);
            }

        }
        /// <summary>
        /// Metoda Usuwa sponsora z projektu
        /// </summary>
        /// <param name="s"></param>
        public void usunSponsora(Sponsor s)
        {
            listaSponsorow.Remove(s);
        }
        /// <summary>
        /// Metoda wybiera wszystkie zadania w projekcie w których wykonaniu uczestniczy Pracownik
        /// </summary>
        /// <param name="p">Pracownik w projekcie</param>
        /// <returns>Listę zadań pracownika w projekcie</returns>
        public List<Zadanie> zadaniaPracownika(Pracownik p)
        {
            List<Zadanie> zadanka=new List<Zadanie>();
            foreach(Zadanie z in listaZadan)
            {
               foreach(Pracownik a in z.Wykonawcy)
                {
                    if (a.Equals(p))
                        zadanka.Add(z);
                }
            }
            return zadanka;
        }
        /// <summary>
        /// Metoda ortuje zadnia wg daty zakonczenia <see cref="Zadanie._czasZakonczenia"/>
        /// <see cref="Zadanie.CompareTo(Zadanie)"/>
        /// </summary>
        /// <param name="zadania">Lista zadań do posortowania</param>
        public static void sortujZadania(List<Zadanie> zadania)
        {
            zadania.Sort();
        }
        /// <summary>
        /// Metoda sprawdza czy w projekcie jest dany pracownik
        /// </summary>
        /// <param name="p">Pracownik do sprawdzenia</param>
        /// <returns>true - jeśli pracownik uczestniczy w projekcie
        /// false- jeśli nie uczestniczy
        /// <see cref="Projekt.listaPracownikow"/></returns>
        public bool maPracownika(Pracownik p)
        {
            foreach(Pracownik x in listaPracownikow)
            {
                if (x.Equals(p))
                    return true;
            }
            return false;
        }

        public object Clone()
        {
            Projekt p = new Projekt();
            List<Zadanie> z1 = new List<Zadanie>();
            List<Pracownik> p1 = new List<Pracownik>();
            List<Sponsor> s1 = new List<Sponsor>();
            //Uwaga: Przy ludziach, nie klonujemy ich jako nowe obiekty
            p.Nazwa = nazwa;
            p.Manager = manager;
            p.Opis = opis;

            
            foreach(var x in listaPracownikow)
            {
                p1.Add(x);
            }
            foreach (var x in listaSponsorow)
            {
                s1.Add(x);
            }
            foreach (var x in listaZadan)
            {
                z1.Add(x);
            }
            p.ListaZadan = z1;
            p.listaSponsorow = s1;
            p.listaPracownikow = p1;

            return p;
        }
        /// <summary>
        /// Metoda wybiera z projektu zadania które mają wykonawców
        /// <see cref="Zadanie._wykonawcy"/>
        /// </summary>
        /// <returns>Listę zadań nad którymi ktoś pracuje</returns>
        public List<Zadanie> wybierzPrzydzielone()
        {
            return listaZadan.Where(z => z.Wykonawcy.Count() != 0 && !z.Wykonane).ToList();
        }
        /// <summary>
        /// Metoda wybiera z projektu zadania które nie mają wykonawców
        /// <see cref="Zadanie._wykonawcy"/>
        /// </summary>
        /// <returns>Listę zadań nad którymi nikt nie pracuje</returns>
        public List<Zadanie> wybierzNieprzydzielone()
        {
            return listaZadan.Where(z => z.Wykonawcy.Count() == 0).ToList();
        }
        /// <summary>
        /// Metoda wybiera z projektu zakonczone zadania
        /// <see cref="Zadanie._wykonane"/>
        /// </summary>
        /// <returns></returns>
        public List<Zadanie> wybierzZakonczone()
        {
            return listaZadan.Where(z => z.Wykonane).ToList();
        }
        /// <summary>
        /// metoda sprawdza czy projektu są takie same
        /// </summary>
        /// <param name="other">Projekt z którym porównujemy</param>
        /// <returns>true - jesli nazwy i managerowie projektow są takie same
        /// false - w przeciwnym wypadku</returns>
        public bool Equals(Projekt other)
        {
            return nazwa.Equals(other.nazwa) && Manager.Equals(other.manager);
        }
    }
}
