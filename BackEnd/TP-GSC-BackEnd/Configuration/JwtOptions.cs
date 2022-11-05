using Microsoft.IdentityModel.Tokens;

namespace TP_GSC_BackEnd.Configuration
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }

        public bool isInvalid() { 
            return Issuer is null || Audience is null || Key is null;
        }
    }
}
