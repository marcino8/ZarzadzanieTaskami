using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Enumy;

namespace Backend
{
    /// <summary>
    /// Zadanie w projekcie
    /// </summary>
    [Serializable]
    public class Zadanie : IComparable<Zadanie>
    {
        /// <summary>
        /// Czas rozpoczecia zadania
        /// </summary>
        DateTime _czasRozpoczecia;
        /// <summary>
        /// Czas zakonczenia zadania
        /// </summary>
        DateTime _czasZakonczenia;
        /// <summary>
        /// Temat zadania
        /// </summary>
        string _temat;
        /// <summary>
        /// Tresc zadania
        /// </summary>
        string _tresc;
        /// <summary>
        /// Czy zadanie jest wykonane
        /// </summary>
        bool _wykonane;
        /// <summary>
        /// Czy zadanie ma opoznienie
        /// </summary>
        bool _opoznienie;
        /// <summary>
        /// Jak wazne jest zadanie
        /// <see cref="Enumy.WaznoscZadania"/>
        /// </summary>
        WaznoscZadania _waznoscZadania;
        /// <summary>
        /// Lista pracownikow pracujacych nad zadaniem
        /// </summary>
        List<Pracownik> _wykonawcy;
        /// <summary>
        /// Lista uwag do zadania
        /// </summary>
        List<Uwaga> _uwagi;

        public DateTime CzasRozpoczecia { get => _czasRozpoczecia; set => _czasRozpoczecia = value; }
        public DateTime CzasZakonczenia { get => _czasZakonczenia; 
            set {
                    _czasZakonczenia = value;
            } 
        }
        public string Temat { get => _temat; set => _temat = value; }
        public string Tresc { get => _tresc; set => _tresc = value; }
        public bool Wykonane { get => _wykonane; set => _wykonane = value; }
        public bool Opoznienie { get => _opoznienie; set => _opoznienie = value; }
        public List<Pracownik> Wykonawcy { get => _wykonawcy; set => _wykonawcy = value; }
        public List<Uwaga> Uwagi { get => _uwagi; set => _uwagi = value; }
        public WaznoscZadania WaznoscZadania { get => _waznoscZadania; set => _waznoscZadania = value; }

        public Zadanie()
        {
            _uwagi = new List<Uwaga>();
            _wykonawcy = new List<Pracownik>();
            CzasRozpoczecia = DateTime.MinValue;
            CzasZakonczenia = DateTime.MinValue;
        }
        public Zadanie(string czasRozpoczecia, string czasZakonczenia, string temat, string tresc, List<Pracownik> wykonawcy, List<Uwaga> uwagi, WaznoscZadania waznoscZadania)
        {
            DateTime.TryParseExact(czasRozpoczecia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd.MM.yyyy", "dd-MM-yyyy" }
            , null, DateTimeStyles.None, out this._czasRozpoczecia);
            DateTime.TryParseExact(czasZakonczenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd.MM.yyyy", "dd-MM-yyyy" }
            , null, DateTimeStyles.None, out this._czasZakonczenia);
            if (_czasRozpoczecia.CompareTo(_czasZakonczenia) > 0)
            {
                throw new NieprawidloweRamyCzasoweException();
            }
            _temat = temat;
            _tresc = tresc;
            _wykonane = false;
            _opoznienie = false;
            _wykonawcy = wykonawcy;
            _uwagi = uwagi;
            _waznoscZadania = waznoscZadania;
        }
        /// <summary>
        /// Przeładowanie toString()
        /// </summary>
        /// <returns>Zwraca informacje o zadaniu jako tekst:
        /// temat zadania, tresc zadania, waznosc zadania i date zakonczenia zadania</returns>
        public override string ToString()
        {
            return $"temat: {Temat} tresc: {Tresc} ważność:{WaznoscZadania}" +
                $" deadline{CzasZakonczenia.ToShortDateString()}";

        }
        /// <summary>
        /// Informacje o zadaniu
        /// </summary>
        /// <returns>Zwraca informacje o zadaniu jako tekst:
        /// temat zadania, tresc zadania, waznosc zadania, date zakonczenia zadania,
        /// wszystkich wykonawcow oraz uwagi</returns>
        public string ToLongString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var x in Wykonawcy)
            {
                sb.Append(x.toShortString());
                sb.Append("\n");
            }
            StringBuilder sb2 = new StringBuilder();
            foreach (var x in Uwagi)
            {
                sb2.Append(x.ToString());
                sb2.Append("\n");
            }
            return $"temat: {Temat}, tresc: {Tresc}, \n" +
                $"Rozpoczecie: {CzasRozpoczecia.ToShortDateString()}\n" +
                $"Przewidywane zakonczenie: {CzasZakonczenia.ToShortDateString()}\n" +
                $"wykonane: {Wykonane}, opoznione?: {_opoznienie},\n" +
                $"Wykonawcy:\n{sb.ToString()}" +
                $"\nUwagi:\n{sb2.ToString()}";
        }
        /// <summary>
        /// Metoda dodaje uwagę do zadania
        /// </summary>
        /// <param name="u">Uwaga do dodania</param>
        public void dodajUwage(Uwaga u)
        {
            _uwagi.Add(u);
        }
        /// <summary>
        /// Metoda oznacza zadanie jako wykonane
        /// </summary>
        public void oznaczJakoZakonczone()
        {
            _wykonane = true;
        }
        /// <summary>
        /// Metoda porównuje Zadania względem czasów zakończenia
        /// </summary>
        /// <param name="other">Zadanie z którym porównujemy</param>
        /// <returns>1 - jeśli zadanie z którym porównujemy kończy się później
        /// 0 - jeśli zadania kończą się tego samego dnia
        /// -1 - jeśli zadanie z którym porównujemy kończy się wcześniej</returns>
        public int CompareTo(Zadanie other)
        {
            return CzasZakonczenia.CompareTo(other.CzasZakonczenia);
        }
    }
}
