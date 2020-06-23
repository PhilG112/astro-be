using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Astro.Abstractions;
using Microsoft.IdentityModel.Tokens;

namespace Astro.Application.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly AppSettings _appSettings;

        public JwtTokenGenerator(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string CreateJwtToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.SecretKey));
            var signInCreds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(_appSettings.ExpiresInHours),
                signingCredentials: signInCreds);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}