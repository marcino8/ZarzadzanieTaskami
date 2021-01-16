using System;
using System.Runtime.Serialization;

namespace Backend
{
    [Serializable]
    internal class NotAPeselException : Exception
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