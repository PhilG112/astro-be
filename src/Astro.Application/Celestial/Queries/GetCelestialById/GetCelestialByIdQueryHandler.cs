using Astro.Abstractions.Data;
using Astro.Application.Celestial.Dtos;
using Astro.Application.Data;
using Astro.Application.EntityModels;
using Astro.Infrastructure.Exceptions;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Queries.GetCelestialById
{
    public class GetCelestialByIdQueryHandler : IQueryHandler<GetCelestialByIdQuery, CelestialObjectDto>
    {
        private readonly ISqlDataRepository _dataRepo;
        private readonly IMapper _mapper;

        public GetCelestialByIdQueryHandler(ISqlDataRepository dataRepo, IMapper mapper)
        {
            _dataRepo = dataRepo;
            _mapper = mapper;
        }

        public async Task<CelestialObjectDto> Handle(GetCelestialByIdQuery request, CancellationToken cancellationToken)
        {
            var celestialObject = await _dataRepo.QueryFirstOrDefaultAsync<CelestialObjectEntityModel>(
                    SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Get),
                    new { Id = request.CelestialId });

            if (celestialObject == null)
            {
                throw new NotFoundException($"No celestial object found for Id: {request.CelestialId}");
            }

            return _mapper.Map<CelestialObjectDto>(celestialObject) ;
        }
    }
}
