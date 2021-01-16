using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    class BazaProjektow 
    {
        List<Projekt> lista_projektow;
        public BazaProjektow()
        {
            this.lista_projektow = new List<Projekt>();
        }

        public static BazaProjektow Wczytaj_Baze()
        {
            if (!File.Exists("archive.xml"))
            {
                throw new FileNotFoundException();
            }
            BazaProjektow b = new BazaProjektow();
            XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
            using (StreamReader sr = new StreamReader("archive.xml"))
            {
                b.lista_projektow = (List<Projekt>)(bf.Deserialize(sr));
            }
            return b;
        }

        public void Zapisz_Baze()
        {

            XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
            using (StreamWriter sw = new StreamWriter("archive.xml"))
            {
                bf.Serialize(sw, this.lista_projektow);
            }

        }

        public void DodajDoBazy(Projekt p)
        {
            lista_projektow.Add(p);
        }

        public void UsunZBazy(Projekt p)
        {
            lista_projektow.Remove(p);
        }

        public void PrzeniesDoArchiwum(Projekt p)
        {
            lista_projektow.Remove(p);
            ArchiwumProjektow a = ArchiwumProjektow.WczytajArchiwum();
            a.ZakonczoneProjekty.Add(p);
            a.ZapiszArchiwum();
        }
    }
}
