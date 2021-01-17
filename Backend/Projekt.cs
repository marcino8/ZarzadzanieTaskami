using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    [Serializable]
    public class Projekt : ICloneable
    {
        string nazwa;
        string opis;
        Manager manager;
        public List<Zadanie> listaZadan;
        public List<Zadanie> wykonaneZadania;
        public List<Pracownik> listaPracownikow;
        public List<Sponsor> listaSponsorow;
        //DateTime dataRozpoczecia;
        //DateTime dataZakonczenia;
        //DateTime deadline;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Opis { get => opis; set => opis = value; }
        public Manager Manager { get => manager; set => manager = value; }
        public List<Zadanie> ListaZadan { get => listaZadan; set => listaZadan = value; }
        public List<Zadanie> WykonaneZadania { get => wykonaneZadania; set => wykonaneZadania = value; }
        public List<Pracownik> ListaPracownikow { get => listaPracownikow; set => listaPracownikow = value; }
        public List<Sponsor> ListaSponsorow { get => listaSponsorow; set => listaSponsorow = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var x in ListaZadan)
            {
                sb.Append(x.toShortString());
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

        public void dodajZadanie(Zadanie z)
        {
            listaZadan.Add(z);
        }

        public void usunZadanie(Zadanie z)
        {
            listaZadan.Remove(z);
        }

        public void dodajPracownika(Pracownik p )
        {
            listaPracownikow.Add(p);
        }
        public void dodajPracownikow(List<Pracownik> p)
        {
            foreach(var x in p)
            {
                listaPracownikow.Add(x);
            }

        }

        public void usunPracownika(Pracownik p)
        {
            listaPracownikow.Remove(p);
        }

        public void dodajSponsora(Sponsor s)
        {
            listaSponsorow.Add(s);
        }
        public void dodajSponsorow(List<Sponsor> p)
        {
            foreach (var x in p)
            {
                listaSponsorow.Add(x);
            }

        }
        public void usunSponsora(Sponsor s)
        {
            listaSponsorow.Remove(s);
        }

        public List<Zadanie> zadaniaPracownika(Pracownik p)
        {
            return listaZadan.Where(z => z.Wykonawcy.Contains(p)).ToList();
        }
        
        public static void sortujZadania(List<Zadanie> zadania)
        {
            zadania.Sort();
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
    }
}
