using Astro.Abstractions.Data;
using Astro.Application.Data;
using Astro.Infrastructure.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Commands.UpdateCelestialObject
{
    public class UpdateCelestialObjectCommandHandler : ICommandHandler<UpdateCelestialObjectCommand>
    {
        private readonly ISqlDataRepository _dataRepo;

        public UpdateCelestialObjectCommandHandler(ISqlDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
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

            var result = await _dataRepo.ExecuteAsync(
                SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Update),
                sqlParams);

            if (result == 0)
            {
                throw new NotFoundException($"Unable to find resource with id '{request.Id}'for deletion.");
            }

            return Unit.Value;
        }
    }
}
