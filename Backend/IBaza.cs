using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    interface IBaza<T>
    {
        void Zapisz_Baze();
        void DodajDoBazy(T element);
        void UsunZBazy(T element);
        T Wczytaj_Baze();
    }
}
