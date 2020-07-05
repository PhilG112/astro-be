using System;
using System.Threading;
using System.Threading.Tasks;
using Astro.Abstractions;
using Astro.Abstractions.Data;
using Astro.Application.Data;
using Astro.Application.DomainEntities;
using Astro.Inftrastructure.Exceptions;
using Dapper;
using FluentValidation;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Astro.Application.Login.Queries.LoginUser
{
    public class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, string>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateOpenConnection();

            var user = await connection.QueryFirstOrDefaultAsync<User>(
                SqlLoader.GetSql(SqlResourceNames.User.User_Get),
                new { request.UserName });

            if (user is null)
            {
                throw new NotFoundException($"User '{request.UserName}' doesn't exist.");
            }

            var correctPassword = VerifyPassword(request.Password, user.PasswordHash, user.Salt);
            if (!correctPassword)
            {
                throw new ValidationException("Incorrect password.");
            }

            return _jwtTokenGenerator.CreateJwtToken();
        }

        private bool VerifyPassword(string given, string passwordHash, string passwordSalt)
        {
            given = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: given,
                salt: Convert.FromBase64String(passwordSalt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 50000,
                numBytesRequested: 512));

            return string.Equals(given, passwordHash);
        }
    }
}