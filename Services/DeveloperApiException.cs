using System.Runtime.Serialization;

namespace BasicApi.Services
{
    [Serializable]
    internal class DeveloperApiException : Exception
    {
        public DeveloperApiException()
        {
        }

        public DeveloperApiException(string? message) : base(message)
        {
        }

        public DeveloperApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DeveloperApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}