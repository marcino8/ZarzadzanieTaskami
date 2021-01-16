using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //Czy to nie za trudne?
    [Serializable]
    public class LiveChat
    {
        Projekt projekt;

        public LiveChat()
        {
        }

        public LiveChat(Projekt projekt)
        {
            this.projekt = projekt;
        }
    }
}
