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
    ///Klasa przechowywująca zakończone projekty
    ///</summary>
    [Serializable]
    public class ArchiwumProjektow
    {
        ///<summary>
        ///Lista zakończonych projektów
        ///</summary>
        List<Projekt> zakonczoneProjekty;

        public ArchiwumProjektow()
        {
            this.zakonczoneProjekty = new List<Projekt>();
        }

        public List<Projekt> ZakonczoneProjekty { get => zakonczoneProjekty; set => zakonczoneProjekty = value; }


        /// <summary>
        /// Metoda wczytywująca archiwum z pliku Archiwum.xml
        /// </summary>
        /// <returns>
        /// Zwraca wczytany obiekt klasy ArchiwumProjektow
        /// </returns>
        public static ArchiwumProjektow WczytajArchiwum()
        {
            ArchiwumProjektow b = new ArchiwumProjektow();
            XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
            using (StreamReader sw = new StreamReader("Archiwum.xml"))
            {
                b.zakonczoneProjekty = (List<Projekt>)(bf.Deserialize(sw));
            }
            return b;
        }

        ///<summary>
        ///Metoda zapisująca archiwum do pliku Archiwum.xml
        ///</summary>
        public void ZapiszArchiwum()
        {
            XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
            using (StreamWriter sw = new StreamWriter("Archiwum.xml"))
            {
                bf.Serialize(sw, this.zakonczoneProjekty);
            }
        }
        /// <summary>
        /// Metoda usuwająca projekt x z archiwum
        /// </summary>
        /// <param name="x">
        /// Projekt do usunięcia
        /// </param>
        public void UsunTrwale(Projekt x)
        {
            zakonczoneProjekty.Remove(x);
        }
        /// <summary>
        /// Metoda dodająca projekt x do archiwum
        /// </summary>
        /// <param name="x">
        /// Projekt który chcemy dodać
        /// </param>
        public void DodajDoArchiwum(Projekt x)
        {
            zakonczoneProjekty.Add(x);
        }
    }
}
