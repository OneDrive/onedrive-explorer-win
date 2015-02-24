using System;

namespace OneDrive
{
    public class ODAuthenticationException : ODServerException
    {
        public ODAuthenticationException(string message)
            : base(message)
        {
        }
    }
}
