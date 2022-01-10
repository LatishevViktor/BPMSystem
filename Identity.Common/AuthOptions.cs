using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Common
{
    public class AuthOptions
    {
        /// <summary>
        /// Список доступных хостов для разрешенного доступа
        /// </summary>
        public List<string> AllowAudiences { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public long AccessTokenExpiration { get; set; }
        public long RefreshTokenExpiration { get; set; }
        public string Secret { get; set; }
    }
}
