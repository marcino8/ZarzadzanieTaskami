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
    public class BazaKont
    {
        List<Konto> lista_kont;
        public BazaKont()
        {
            this.lista_kont = new List<Konto>();
        }

        public static BazaKont Wczytaj_Baze(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            BazaKont b  = new BazaKont();
            XmlSerializer bf = new XmlSerializer(typeof(BazaKont));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                b = (BazaKont)(bf.Deserialize(sw));
            }
            return b;
        }

        public void Zapisz_Baze(string nazwaPliku)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(BazaKont));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, this);
            }
        }

        public void DodajDoBazy(Konto k)
        {
            lista_kont.Add(k);
        }

        public void UsunZBazy(Konto k)
        {
            lista_kont.Remove(k);
        }

        public bool SprawdzKonto(string login, string password)
        {
            return lista_kont.Any(k => k.Login.Equals(login) && k.Haslo.Equals(password));
        }

        //przetestowac
        public List<Konto> wybierzKonta(Uzytkownik u)
        {
            return lista_kont.Where(k => k.Uzytkownik.GetType().Equals(u.GetType())).ToList();
        } 
    }
}
