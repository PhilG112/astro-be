using Astro.Abstractions.Data;
using Astro.Application.Data;
using Astro.Infrastructure.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Commands.DeleteCelestialObject
{
    class DeleteCelestialObjectCommandHandler : ICommandHandler<DeleteCelestialObjectCommand>
    {
        private readonly ISqlDataRepository _dataRepo;

        public DeleteCelestialObjectCommandHandler(ISqlDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public async Task<Unit> Handle(DeleteCelestialObjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _dataRepo.ExecuteAsync(
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
