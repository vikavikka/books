using Prog2WebApi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Prog2WebApi.Services
{
    public class AuthenticationService
    {
        public static string CreateJwtToken(User user)
        {
            // aizpildam informāciju par lietotāju - claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // izveidojam atslēgu, ar kuru šifrēsim tokenu
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("BOOKS_LIELS_NOSLEPUMS_BOOKS_LIELS_NOSLEPUMS")
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // norādam visus tokena atribūtus
            var token = new JwtSecurityToken(
                issuer: "books_api",
                audience: "books_api",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
