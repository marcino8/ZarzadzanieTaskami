using System;
using System.Runtime.Serialization;

namespace Backend
{
    ///<summary>
    ///Klasa wyjątku daty zakonczenia wczesniejszej niz data rozpoczecia projektu
    /// </summary>
    [Serializable]
    public class NieprawidloweRamyCzasoweException : Exception
    {
        public NieprawidloweRamyCzasoweException()
        {
        }

        public NieprawidloweRamyCzasoweException(string message) : base(message)
        {
        }

        public NieprawidloweRamyCzasoweException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NieprawidloweRamyCzasoweException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}