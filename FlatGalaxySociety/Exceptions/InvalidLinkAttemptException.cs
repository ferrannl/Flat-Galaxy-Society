using System;
using System.Runtime.Serialization;

namespace FlatGalaxySociety
{
    [Serializable]
    public class InvalidLinkAttemptException : Exception
    {
        public InvalidLinkAttemptException()
        {
        }

        public InvalidLinkAttemptException(string message) : base(message)
        {
        }

        public InvalidLinkAttemptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLinkAttemptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}