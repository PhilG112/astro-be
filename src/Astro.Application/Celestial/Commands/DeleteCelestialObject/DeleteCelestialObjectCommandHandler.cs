using Astro.Abstractions.Data;
using Astro.Application.Data;
using Astro.Infrastructure.Exceptions;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Commands.DeleteCelestialObject
{
    class DeleteCelestialObjectCommandHandler : ICommandHandler<DeleteCelestialObjectCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnFactory;

        public DeleteCelestialObjectCommandHandler(ISqlConnectionFactory sqlConnFactory)
        {
            _sqlConnFactory = sqlConnFactory;
        }

        public async Task<Unit> Handle(DeleteCelestialObjectCommand request, CancellationToken cancellationToken)
        {
            using var conn = _sqlConnFactory.CreateOpenConnection();

            var result = await conn.ExecuteAsync(
                SqlLoader.GetSql(sqlResourceName: SqlResourceNames.CelestialObjects.CelestialObject_Delete),
                new { Id = request.CelestialObjectId });

            if (result == 0)
            {
                throw new NotFoundException($"Unable to find resource with id '{request.CelestialObjectId}'for deletion.");
            }

            return Unit.Value;
            
        }
    }
}
