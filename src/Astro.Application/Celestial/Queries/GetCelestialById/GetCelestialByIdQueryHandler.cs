using Astro.Abstractions.Data;
using Astro.Application.Celestial.Dtos;
using Astro.Application.Data;
using Astro.Application.EntityModels;
using Astro.Infrastructure.Exceptions;
using AutoMapper;
using Dapper;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Queries.GetCelestialById
{
    public class GetCelestialByIdQueryHandler : IQueryHandler<GetCelestialByIdQuery, CelestialObjectDto>
    {
        private readonly ISqlConnectionFactory _sqlConnFactory;
        private readonly IMapper _mapper;

        public GetCelestialByIdQueryHandler(ISqlConnectionFactory sqlConnFactory, IMapper mapper)
        {
            _sqlConnFactory = sqlConnFactory;
            _mapper = mapper;
        }

        public async Task<CelestialObjectDto> Handle(GetCelestialByIdQuery request, CancellationToken cancellationToken)
        {
            using var conn = _sqlConnFactory.CreateOpenConnection();

            var celestialObject = await conn.QueryFirstOrDefaultAsync<CelestialObjectEntityModel>(
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
