using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Astro.API.Application.Response.LogIn;
using Dapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Astro.API.Application.Auth
{
    public class LogInManager : ILogInManager
    {
        private readonly string _connString;
        private readonly string _secretKey;
        private readonly ILogger _log = Log.ForContext<LogInManager>();

        public LogInManager(string connString, string secretKey)
        {
            _connString = connString;
            _secretKey = secretKey;
        }

        public async Task<LogInRequestResult> LogIn(string userName, string password)
        {
            using (var conn = new SqlConnection(_connString))
            {
                try
                {
                    await conn.OpenAsync();

                    var sql = $@"SELECT * FROM dbo.Users as u
                                 WHERE u.UserName = @UserName";

                    var query = await conn.QueryFirstOrDefaultAsync<AppUser>(sql, new { UserName = userName });
                    if (query == null)
                    {
                        _log.Error($"No such user: {userName}");
                        return new LogInRequestResult(notFound: true);
                    }

                    var correctPassword = VerifyPassword(password, query.PasswordHash, query.Salt);
                    if (!correctPassword)
                    {
                        _log.Error($"Invalid password for user: {userName} - password: {password}");
                        return new LogInRequestResult(notFound: true);
                    }

                    var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
                    var signInCreds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                    var tokenOptions = new JwtSecurityToken(
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signInCreds);

                    var result = new LogInRequestResponseModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions)
                    };

                    return new LogInRequestResult(result);
                }
                catch (Exception ex)
                {
                    _log.Error(ex, "Unable to login.");
                    return new LogInRequestResult(ex);
                }
            }
        }

        private bool VerifyPassword(string given, string passwordHash, string passwordSalt)
        {
            given = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: given,
                salt: Convert.FromBase64String(passwordSalt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return string.Equals(given, passwordHash);
        }

        private class AppUser
        {
            public string UserName { get; set; }

            public string PasswordHash { get; set; }

            public string Salt { get; set; }
        }
    }
}
