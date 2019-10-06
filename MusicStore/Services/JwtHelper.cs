using Microsoft.IdentityModel.Tokens;
using MSt.Data.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MusicStore.Services
{
    public class JwtHelper
    {
        private readonly JwtConfiguration _configuration;

        private byte[] Key => Encoding.ASCII.GetBytes(_configuration.JwtSecretKey);

        public JwtHelper(JwtConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(User user, IEnumerable<System.Security.Claims.Claim> claims = null)
        {

            var userClaims = new[]
                {
                    new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                }
                .Concat(
                    claims ?? new System.Security.Claims.Claim[0]
                )
                .ToList();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return CreateToken(tokenDescriptor);
        }

        private static string CreateToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
