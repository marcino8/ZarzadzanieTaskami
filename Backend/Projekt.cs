using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Projekt : ICloneable
    {
        string nazwa;
        string opis;
        Manager manager;
        List<Zadanie> listaZadan;
        List<Zadanie> wykonaneZadania;
        List<Pracownik> listaPracownikow;
        List<Sponsor> listaSponsorow;
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

        public Projekt()
        {
            this.listaZadan = new List<Zadanie>();
            this.wykonaneZadania = new List<Zadanie>();
            this.listaPracownikow = new List<Pracownik>();
        }

        public Projekt(Manager manager)
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
            p.Projekty.Add(this);
        }

        public void usunPracownika(Pracownik p)
        {
            listaPracownikow.Remove(p);
            p.Projekty.Remove(this);
        }

        public void dodajSponsora(Sponsor s)
        {
            listaSponsorow.Add(s);
            s.Projekty.Add(this);
        }
        public void usunSponsora(Sponsor s)
        {
            listaSponsorow.Remove(s);
            s.Projekty.Remove(this);
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
