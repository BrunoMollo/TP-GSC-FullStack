using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP_GSC_BackEnd.Configuration;
using TP_GSC_BackEnd.Dto.UserDto;

namespace TP_GSC_BackEnd.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtOptions _jwtOptions;

        public JwtHandler(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions?.Value ?? throw new ArgumentException(nameof(jwtOptions));
           
            if(_jwtOptions.isInvalid())
                throw new ArgumentException(nameof(jwtOptions));
        }




        public string GenerateToken(LoginUserDto user, IEnumerable<string> roles)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user, roles);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }




        private SigningCredentials GetSigningCredentials()
        {
            byte[] keyRaw = Encoding.UTF8.GetBytes(_jwtOptions.Key); 
           
            var secretkey = new SymmetricSecurityKey(keyRaw);

            return new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
        }


        private List<Claim> GetClaims(LoginUserDto user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
           
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            
            return claims;
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                claims: claims,
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                signingCredentials: signingCredentials
            );
        }



    }
}
