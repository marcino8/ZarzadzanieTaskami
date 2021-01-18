using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backend
{
    [Serializable]
    public class ArchiwumProjektow
    {
        List<Projekt> zakonczoneProjekty;

        public ArchiwumProjektow()
        {
            this.zakonczoneProjekty = new List<Projekt>();
        }

        public List<Projekt> ZakonczoneProjekty { get => zakonczoneProjekty; set => zakonczoneProjekty = value; }

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

        public void ZapiszArchiwum()
        {
            XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
            using (StreamWriter sw = new StreamWriter("Archiwum.xml"))
            {
                bf.Serialize(sw, this.zakonczoneProjekty);
            }
        }

        public void UsunTrwale(Projekt x)
        {
            zakonczoneProjekty.Remove(x);
        }
        
        public void DodajDoArchiwum(Projekt x)
        {
            zakonczoneProjekty.Add(x);
        }
    }
}
