using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class BazaKont
    {
        List<Konto> lista_kont;
        public BazaKont()
        {
            this.lista_kont = new List<Konto>();
        }

        static BazaKont Wczytaj_Baze()
        {
            return null;
        }

        static void Zapisz_Baze()
        {
            
        }

        public void DodajDoBazy()
        {

        }

        public void UsunZBazy()
        {

        }

        public bool SprawdzKonto(string login, string password)
        {
            return true;
        }

        public List<Konto> wybierzKonta()
        {
            return null;
        } 
    }
}
