using Astro.Abstractions.Data;
using Astro.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Commands.CreateCelestialObject
{
    public class CreateCelestialObjectCommandHandler : ICommandHandler<CreateCelestialObjectCommand, int>
    {
        private readonly ISqlDataRepository _dataRepo;

        public CreateCelestialObjectCommandHandler(ISqlDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public async Task<int> Handle(CreateCelestialObjectCommand request, CancellationToken cancellationToken)
        {
            var sqlParams = new
            {
                ObjectType = request.ObjectType.ToString(),
                request.Magnitude,
                request.AbsoluteMagnitude,
                request.Name,
                request.Designation1,
                request.Designation2,
                request.Designation3,
                request.Designation4,
                request.Description,
                request.Distance,
                request.DistanceTolerance
            };

            var createResultId = await _dataRepo.QueryFirstAsync<int>(
                SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Create),
                sqlParams);

            return createResultId;
        }
    }
}
