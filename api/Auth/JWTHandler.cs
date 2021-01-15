using api.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.Auth
{
    public class JWTHandler
    {
        public string GenerateToken(User userLoggedIn, string key, string issuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userLoggedIn.Email),
                new Claim("Username", userLoggedIn.Username),
                new Claim("UserId", userLoggedIn.UserId.ToString()),
                new Claim("Role", userLoggedIn.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetClaim(string token, string claimName)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
            return securityToken.Claims.First(claim => claim.Type == claimName).Value;
        }
    }
}
