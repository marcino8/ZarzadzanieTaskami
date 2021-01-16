using Newtonsoft.Json;
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

        public static BazaKont Wczytaj_Baze()
        {
            if (!File.Exists("userbase.xml"))
            {
                throw new FileNotFoundException();
            }
            BazaKont b = new BazaKont();
            XmlSerializer bf = new XmlSerializer(typeof(List<Konto>));
            using (StreamReader sr = new StreamReader("userbase.xml"))
            {
                b.lista_kont = (List<Konto>)(bf.Deserialize(sr));
            }
            return b;
        }

        public void Zapisz_Baze()
        {

            XmlSerializer bf = new XmlSerializer(typeof(List<Konto>));
            using (StreamWriter sw = new StreamWriter("userbase.xml"))
            {
                bf.Serialize(sw, this.lista_kont);
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
