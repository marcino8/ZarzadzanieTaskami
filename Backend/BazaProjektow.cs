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
    public class BazaProjektow 
    {
        List<Projekt> lista_projektow;
        int ilosc_projektow;

        public List<Projekt> Lista_projektow { get => lista_projektow; set => lista_projektow = value; }

        public BazaProjektow()
        {
            this.lista_projektow = new List<Projekt>();
            ilosc_projektow = 0;
        }

        public static BazaProjektow Wczytaj_Baze()
        {
            if (!File.Exists("archive.xml"))
            {
                throw new FileNotFoundException();
            }
            /* BazaProjektow b = new BazaProjektow();
             int ilosc = 0;
             XmlSerializer bf = new XmlSerializer(typeof(List<Projekt>));
             using (StreamReader sr = new StreamReader("archive.xml"))
             {
                 b.lista_projektow = (List<Projekt>)(bf.Deserialize(sr));
             }
             b.ilosc_projektow = ilosc;
 */
            BazaProjektow b = new BazaProjektow();
            int ilosc = 0;
            XmlSerializer bf = new XmlSerializer(typeof(int));
            using (StreamReader sr = new StreamReader("archive/Ilosc.xml"))
            {
                ilosc = (int)(bf.Deserialize(sr));
            }
            b.ilosc_projektow = ilosc;
            List<Zadanie> list1;
            List<Zadanie> list2;
            List<Pracownik> list3;
            List<Sponsor> list4;
            string nazwa;
            string opis;
            Manager manager;
            for (int i = 1; i <= b.ilosc_projektow; i++)
            {
                bf = new XmlSerializer(typeof(string));
                using (StreamReader sr = new StreamReader($"archive/Nazwa{i}.xml"))
                {
                    nazwa = (string)bf.Deserialize(sr);
                    
                }
                bf = new XmlSerializer(typeof(string));
                using (StreamReader sr = new StreamReader($"archive/Opis{i}.xml"))
                {
                    opis = (string)bf.Deserialize(sr);
                   
                }
                bf = new XmlSerializer(typeof(Manager));
                using (StreamReader sr = new StreamReader($"archive/Manager{i}.xml"))
                {
                    manager = (Manager)bf.Deserialize(sr);
                    
                }

                bf = new XmlSerializer(typeof(List<Zadanie>));
                using (StreamReader sr = new StreamReader($"archive/Zadania{i}.xml"))
                {
                    list1 = (List<Zadanie>)bf.Deserialize(sr);
                    
                }
                bf = new XmlSerializer(typeof(List<Zadanie>));
                using (StreamReader sr = new StreamReader($"archive/ZadaniaWykonane{i}.xml"))
                {
                    list2 = (List<Zadanie>)bf.Deserialize(sr);
                    
                }
                bf = new XmlSerializer(typeof(List<Pracownik>));
                using (StreamReader sr = new StreamReader($"archive/Pracownicy{i}.xml"))
                {
                    list3 = (List<Pracownik>)bf.Deserialize(sr);
                }
                bf = new XmlSerializer(typeof(List<Sponsor>));
                using (StreamReader sr = new StreamReader($"archive/Sponsorzy{i}.xml"))
                {
                    list4 = (List<Sponsor>)bf.Deserialize(sr);
                }
                
                b.lista_projektow.Add(new Projekt(nazwa, opis, manager, list1, list2, list3, list4));
            }
            return b;
        }

        public void Zapisz_Baze()
        {
            /* XmlSerializer bf= new XmlSerializer(typeof(List<Projekt>));
              using (StreamWriter sw = new StreamWriter("archive.xml"))
              {
                  bf.Serialize(sw, this.lista_projektow);
              }*/
            XmlSerializer bf = new XmlSerializer(typeof(int));
            using (StreamWriter sw = new StreamWriter("archive/Ilosc.xml"))
            {
                bf.Serialize(sw, this.ilosc_projektow);
            }
            int i = 1;
            foreach (Projekt projekt in lista_projektow)
            {
                bf = new XmlSerializer(typeof(string));
                using (StreamWriter sw = new StreamWriter($"archive/Nazwa{i}.xml"))
                {
                    bf.Serialize(sw, projekt.Nazwa);
                }
                bf = new XmlSerializer(typeof(string));
                using (StreamWriter sw = new StreamWriter($"archive/Opis{i}.xml"))
                {
                    bf.Serialize(sw, projekt.Opis);
                }
                bf = new XmlSerializer(typeof(Manager));
                using (StreamWriter sw = new StreamWriter($"archive/Manager{i}.xml"))
                {
                    bf.Serialize(sw, projekt.Manager);
                }
                bf = new XmlSerializer(typeof(List<Zadanie>));
                using (StreamWriter sw = new StreamWriter($"archive/Zadania{i}.xml"))
                {
                    bf.Serialize(sw, projekt.ListaZadan);
                }
                bf = new XmlSerializer(typeof(List<Zadanie>));
                using (StreamWriter sw = new StreamWriter($"archive/ZadaniaWykonane{i}.xml"))
                {
                    bf.Serialize(sw, projekt.WykonaneZadania);
                }
                bf = new XmlSerializer(typeof(List<Pracownik>));
                using (StreamWriter sw = new StreamWriter($"archive/Pracownicy{i}.xml"))
                {
                    bf.Serialize(sw, projekt.ListaPracownikow);
                }
                bf = new XmlSerializer(typeof(List<Sponsor>));
                using (StreamWriter sw = new StreamWriter($"archive/Sponsorzy{i}.xml"))
                {
                    bf.Serialize(sw, projekt.ListaSponsorow);
                }
                i++;
            }


        }

        public void DodajDoBazy(Projekt p)
        {
            ilosc_projektow++;
            lista_projektow.Add(p);
        }

        public bool UsunZBazy(Projekt p)
        {
            bool t = false;
            ilosc_projektow--;
            int a=lista_projektow.IndexOf(p);
            if (File.Exists($"archive/Nazwa{a}.xml"))
            {
                File.Delete($"archive/Nazwa{a}.xml");
            }
            if (File.Exists($"archive/Opis{a}.xml"))
            {
                File.Delete($"archive/Opis{a}.xml");
            }
            if (File.Exists($"archive/Manager{a}.xml"))
            {
                File.Delete($"archive/Manager{a}.xml");
            }
            if (File.Exists($"archive/Zadania{a}.xml"))
            {
                File.Delete($"archive/Zadania{a}.xml");
            }
            if (File.Exists($"archive/ZadaniaWykonane{a}.xml"))
            {
                File.Delete($"archive/ZadaniaWykonane{a}.xml");
            }
            if (File.Exists($"archive/Pracownicy{a}.xml"))
            {
                File.Delete($"archive/Pracownicy{a}.xml");
            }
            if (File.Exists($"archive/Sponsorzy{a}.xml"))
            {
                File.Delete($"archive/Sponsorzy{a}.xml");
            }
            t=lista_projektow.Remove(p);
            for(int i = a + 1; i < ilosc_projektow; i++)
            {
                if (File.Exists($"archive/Nazwa{i}.xml"))
                {
                    File.Move($"archive/Nazwa{i}.xml", $"archive/Nazwa{i - 1}.xml");
                }
                if (File.Exists($"archive/Opis{i}.xml"))
                {
                    File.Move($"archive/Opis{i}.xml", $"archive/Opis{i - 1}.xml");
                }
                if (File.Exists($"archive/Manager{i}.xml"))
                {
                    File.Move($"archive/Manager{i}.xml", $"archive/Manager{i - 1}.xml");
                }
                if (File.Exists($"archive/Zadania{i}.xml"))
                {
                    File.Move($"archive/Zadania{i}.xml", $"archive/Zadania{i - 1}.xml");
                }
                if (File.Exists($"archive/ZadaniaWykonane{i}.xml"))
                {
                    File.Move($"archive/ZadaniaWykonane{i}.xml", $"archive/ZadaniaWykonane{i - 1}.xml");
                }
                if (File.Exists($"archive/Pracownicy{i}.xml"))
                {
                    File.Move($"archive/Pracownicy{i}.xml", $"archive/Pracownicy{i - 1}.xml");
                }
                if (File.Exists($"archive/Sponsorzy{i}.xml"))
                {
                    File.Move($"archive/Sponsorzy{i}.xml", $"archive/Sponsorzy{i - 1}.xml");
                }
            }
            return t;

        }

        public void PrzeniesDoArchiwum(Projekt p)
        {
            lista_projektow.Remove(p);
            ArchiwumProjektow a = ArchiwumProjektow.WczytajArchiwum();
            a.ZakonczoneProjekty.Add(p);
            a.ZapiszArchiwum();
        }

        public List<Projekt> wyszukajProjekty(Uzytkownik u)
        {
            List<Projekt> k = new List<Projekt>();
            foreach(Projekt f in lista_projektow)
            {
                foreach(Pracownik p in f.ListaPracownikow)
                {
                    if (p.Equals(u))
                        k.Add(f);
                }
                foreach(Sponsor s in f.ListaSponsorow)
                {
                    if (s.Equals(u))
                        k.Add(f);
                }
                if (f.Manager.Equals(u))
                    k.Add(f);
            }
            return k;
        }
    }
}
