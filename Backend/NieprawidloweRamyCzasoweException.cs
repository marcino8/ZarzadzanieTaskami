using System;
using System.Runtime.Serialization;

namespace Backend
{
    [Serializable]
    internal class NieprawidloweRamyCzasoweException : Exception
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