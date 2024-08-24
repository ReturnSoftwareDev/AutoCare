using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Tools
{
    public class JwtTokenModel
    {
        //public const string ValidAudience = "77.245.159.27";
        //public const string ValidIssuer = "77.245.159.27";
        //public const string Key = "AutoCareJWT123456789.Asp.NetCoreJWTKey";
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Key { get; set; }
    }
}
