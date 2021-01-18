using System;
using System.Runtime.Serialization;

namespace Backend
{
    ///<summary>
    ///Klasa wyjątku służąca do sprawdzania czy pesel napewno ma 11 znaków
    ///</summary>
    [Serializable]
    public class NotAPeselException : Exception
    {
        public NotAPeselException()
        {
        }

        public NotAPeselException(string message) : base(message)
        {
        }

        public NotAPeselException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAPeselException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}