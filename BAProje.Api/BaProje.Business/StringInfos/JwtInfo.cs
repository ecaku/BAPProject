using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost:51061";
        public const string Audience = "http://localhost:5000";
        public const string SecurityKey = "emreemreemreemre";
        public const double expires = 40;
    }
}
