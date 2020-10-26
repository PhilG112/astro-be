using Astro.Abstractions.Data;
using Astro.Application.Data;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Commands.UpdateCelestialObject
{
    public class UpdateCelestialObjectCommandHandler : ICommandHandler<UpdateCelestialObjectCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnFactory;

        public UpdateCelestialObjectCommandHandler(ISqlConnectionFactory sqlConnFactory)
        {
            _sqlConnFactory = sqlConnFactory;
        }

        public async Task<Unit> Handle(UpdateCelestialObjectCommand request, CancellationToken cancellationToken)
        {
            var sqlParams = new
            {
                request.Id,
                request.Magnitude,
                request.AbsoluteMagnitude,
                request.Name,
                ObjectType = request.ObjectType.ToString(),
                request.Designation1,
                request.Designation2,
                request.Designation3,
                request.Designation4,
                request.Description,
                request.Distance,
                request.DistanceTolerance
            };

            using var conn = _sqlConnFactory.CreateOpenConnection();

            await conn.ExecuteAsync(
                SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Update),
                sqlParams);

            return Unit.Value;
        }
    }
}
