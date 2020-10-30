using System;
using System.Runtime.Serialization;

namespace FlatGalaxySociety
{
    [Serializable]
    public class NoFileSelectedException : Exception
    {
        public NoFileSelectedException()
        {
        }

        public NoFileSelectedException(string message) : base(message)
        {
        }

        public NoFileSelectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoFileSelectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}