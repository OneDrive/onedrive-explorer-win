using System;

namespace OneDrive
{
    public class ODSerializationException : ODException
    {
        public string JsonData { get; private set; }

        internal ODSerializationException(string message, string jsonData, Exception innerException = null)
            : base(message, innerException)
        {
            JsonData = jsonData;
        }
    }
}
