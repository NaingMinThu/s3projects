using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PayLoadAPI.Interfaces;
using PayLoadAPI.VModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayLoadAPI.Controllers
{
    public class JwTManager : IJwtManager
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="JwTManager"/> class.
        /// </summary>
        /// <param name="iconfiguration">The iconfiguration.</param>
        public JwTManager(IConfiguration iconfiguration)
        {
            this._configuration = iconfiguration;
        }
        /// <summary>
        /// Gets the JWT toen.
        /// </summary>
        /// <returns>A Tokens.</returns>
        public Tokens GetJWTToken()
        {
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
           
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Username", username)
                    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens
            {
                Token = tokenHandler.WriteToken(token)
            };

        }
    }
}
