using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDrive
{
    public class SimpleAuthenticationInfo : IAuthenticationInfo
    {
        public SimpleAuthenticationInfo()
        {
            TokenType = "Bearer";
            TokenExpiration = DateTimeOffset.MaxValue;
        }

        public string AccessToken
        {
            get;
            set;
        }

        public string RefreshToken
        {
            get;
            set;
        }

        public string TokenType
        {
            get;
            set;
        }

        public DateTimeOffset TokenExpiration
        {
            get;
            set;
        }

        public Task<bool> RefreshAccessTokenAsync()
        {
            throw new NotSupportedException();
        }

        public string AuthorizationHeaderValue
        {
            get { return string.Format("{0} {1}", TokenType, AccessToken); }
        }
    }
}
