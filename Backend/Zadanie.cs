using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    class Zadanie
    {
        DateTime _czasRozpoczecia;
        DateTime _czasZakonczenia;
        string _temat;
        string _tresc;
        bool _wykonane;
        bool opoznienie;
        enum 
        List<Pracownik> _wykonawcy;
        List<Uwaga> _uwagi;

        public DateTime CzasRozpoczecia { get => _czasRozpoczecia; set => _czasRozpoczecia = value; }
        public DateTime CzasZakonczenia { get => _czasZakonczenia; set => _czasZakonczenia = value; }
        public string Temat { get => _temat; set => _temat = value; }
        public string Tresc { get => _tresc; set => _tresc = value; }
        public bool Wykonane { get => _wykonane; set => _wykonane = value; }
        public bool Opoznienie { get => opoznienie; set => opoznienie = value; }
        public List<Pracownik> Wykonawcy { get => _wykonawcy; set => _wykonawcy = value; }
        public List<Uwaga> Uwagi { get => _uwagi; set => _uwagi = value; }

        public Zadanie()
        {

        }
        public Zadanie(DateTime czasRozpoczecia, DateTime czasZakonczenia, string temat, string tresc, bool wykonane, bool opoznienie, List<Pracownik> wykonawcy, List<Uwaga> uwagi)
        {
            _czasRozpoczecia = czasRozpoczecia;
            _czasZakonczenia = czasZakonczenia;
            _temat = temat;
            _tresc = tresc;
            _wykonane = wykonane;
            this.opoznienie = opoznienie;
            _wykonawcy = wykonawcy;
            _uwagi = uwagi;
        }

        public void dodajUwage()
        {

        }

        public void oznaczJakoZakonczone()
        {

        }
    }
}
