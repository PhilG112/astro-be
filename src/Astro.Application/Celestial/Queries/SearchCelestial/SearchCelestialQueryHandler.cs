using Astro.Abstractions.Data;
using Astro.Application.Celestial.Dtos;
using Astro.Application.Data;
using Astro.Application.EntityModels;
using AutoMapper;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Queries.SearchCelestial
{
    public class SearchCelestialQueryHandler : IQueryHandler<SearchCelestialQuery, IEnumerable<CelestialObjectDto>>
    {
        private IMapper _mapper;
        private ISqlConnectionFactory _sqlConnFactory;

        public SearchCelestialQueryHandler(IMapper mapper, ISqlConnectionFactory sqlConnFactory)
        {
            _mapper = mapper;
            _sqlConnFactory = sqlConnFactory;
        }

        public async Task<IEnumerable<CelestialObjectDto>> Handle(SearchCelestialQuery request, CancellationToken cancellationToken)
        {
            using var sqlConn = _sqlConnFactory.CreateOpenConnection();

            var searchResult = await sqlConn.QueryAsync<CelestialObjectEntityModel>(
                    SqlLoader.GetSql(SqlResourceNames.CelestialObjects.CelestialObject_Search),
                    new { searchText = $"\"{request.SearchText}*\"" });

            if (searchResult == null)
            {
                return new List<CelestialObjectDto>();
            }

            return searchResult.Select(c => _mapper.Map<CelestialObjectDto>(c));
        }
    }
}
