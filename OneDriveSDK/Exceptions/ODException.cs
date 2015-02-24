using System;

namespace OneDrive
{
    public class ODException : Exception
    {
        internal ODException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
