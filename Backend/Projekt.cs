using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Projekt
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
        }

        public void usunPracownika(Pracownik p)
        {
            listaPracownikow.Remove(p);
        }

        public void dodajSponsora(Sponsor s)
        {
            listaSponsorow.Add(s);
        }
        public void usunSponsora(Sponsor s)
        {
            listaSponsorow.Remove(s);
        }



    }
}
