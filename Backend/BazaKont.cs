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

        public Uzytkownik wyciagnijUzytkownika(string login, string password)
        {
            if(SprawdzKonto(login, password))
            {
                return lista_kont.First(k => k.Login.Equals(login) && k.Haslo.Equals(password)).Uzytkownik;
            }
            return null;
        }

        //przetestowac
        public List<Konto> wybierzKonta(Uzytkownik u)
        {
            return lista_kont.Where(k => k.Uzytkownik.GetType().Equals(u.GetType())).ToList();
        }

        public List<Uzytkownik> wybierzOsoby(Uzytkownik u)
        {
            List<Uzytkownik> list = new List<Uzytkownik>();
            foreach (Konto k in lista_kont)
            {
                if (k.Uzytkownik.GetType().Equals(u.GetType()))
                    list.Add(k.Uzytkownik);
            }
            return list;
        }
        public List<Uzytkownik> wybierzOsobyNieWProjekcie(Uzytkownik u, Projekt p)
        {
            List<Uzytkownik> list = new List<Uzytkownik>();
            
            foreach (Konto k in lista_kont)
            {
                if (k.Uzytkownik.GetType().Equals(u.GetType()))
                {
                    Console.WriteLine("TU WCHODZI");
                    if (!p.maPracownika((Pracownik)k.Uzytkownik))
                    {
                        list.Add(k.Uzytkownik);
                        Console.WriteLine("A TU?");
                    }
                }
                    
            }
            return list;
        }
         public int SprawdzKto(string login, string haslo)
        {
            if (SprawdzKonto(login, haslo))
            {
                Uzytkownik u = lista_kont.First(k => k.Login.Equals(login) && k.Haslo.Equals(haslo)).Uzytkownik;
                if (u is Pracownik)
                    return 1; //Pracownik
                if (u is Sponsor)
                    return 2; //Sponsor
                else
                    return 3; //Manager
            }
            return -1;
        }
    }
}
