using System;
using System.Runtime.Serialization;

namespace Tema1PSSC.Domain
{
    [Serializable]
    internal class InvalidPrice : Exception
    {
        public InvalidPrice()
        {
        }

        public InvalidPrice(string? message) : base(message)
        {
        }

        public InvalidPrice(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPrice(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
