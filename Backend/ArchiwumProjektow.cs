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

        public static ArchiwumProjektow WczytajArchiwum()
        {
            ArchiwumProjektow b = new ArchiwumProjektow();
            XmlSerializer bf = new XmlSerializer(typeof(BazaKont));
            using (StreamReader sw = new StreamReader("Archiwum.xml"))
            {
                b = (ArchiwumProjektow)(bf.Deserialize(sw));
            }
            return b;
        }

        public void Zapisz()
        {
            XmlSerializer bf = new XmlSerializer(typeof(ArchiwumProjektow));
            using (StreamWriter sw = new StreamWriter("Archiwum.xml"))
            {
                bf.Serialize(sw, this);
            }
        }
    }
}
