using ApiAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAuthentication.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly List<User> _users = new()
        {
            new User()
            {
                UserName = "admin",
                Password = "admin",
                Role = "administrator"
            },
            new User()
            {
                UserName = "user",
                Password = "user",
                Role = "user"
            }
        };

        private readonly string _securityKey;
        private readonly string _validIssuer;

        public JwtTokenService(IConfiguration configuration)
        {
            _securityKey = configuration["JwtTokenConfig:SecurityKey"] ?? throw new ArgumentException("SecurityKey must be informed");
            _validIssuer = configuration["JwtTokenConfig:Issuer"] ?? throw new ArgumentException("Issuer must be informed");
        }

        public AuthToken? GenerateAuthToken(Login model)
        {
            var user = _users.FirstOrDefault(u => u.UserName == model.User && u.Password == model.Password);
            if (user is null)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeSpan = DateTime.Now.AddMinutes(10);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
                new Claim("role", user.Role)
            };

            foreach(var scope in user.Scopes)
            {
                claims.Add(new Claim("scope", scope));
            }

            var tokenOptions = new JwtSecurityToken(
                issuer: _validIssuer,
                claims: claims,
                expires: expirationTimeSpan,
                signingCredentials: signingCredentials
                );

            var authToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthToken
            {
                Token = authToken,
                ExpiresIn = (int)expirationTimeSpan.Subtract(DateTime.Now).TotalSeconds,
            };
        }
    }
}
