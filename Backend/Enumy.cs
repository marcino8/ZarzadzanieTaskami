using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    ///<summary>
    ///Klasa przechowywująca enumy
    ///</summary>
    [Serializable]
    public class Enumy
    {
        ///<summary>
        ///Enum dotyczący ważności zadania
        ///</summary>
        public enum WaznoscZadania
        {
            Mało_istotne = 1,
            Istotne = 2,
            Ważne=3,
            Krytycznie_ważne=4
        }
    }
}
