using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CheckPassword.API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CheckPassword.API.Services
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("Minha_Chave_Secreta_Muito_Longa_E_Segura_1029");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
