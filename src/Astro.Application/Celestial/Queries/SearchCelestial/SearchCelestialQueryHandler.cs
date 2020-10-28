using Astro.Abstractions.Data;
using Astro.Application.Celestial.Dtos;
using Astro.Application.Data;
using Astro.Application.EntityModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Astro.Application.Celestial.Queries.SearchCelestial
{
    public class SearchCelestialQueryHandler : IQueryHandler<SearchCelestialQuery, IEnumerable<CelestialObjectDto>>
    {
        private readonly ISqlDataRepository _dataRepo;
        private readonly IMapper _mapper;

        public SearchCelestialQueryHandler(ISqlDataRepository dataRepo, IMapper mapper)
        {
            _dataRepo = dataRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CelestialObjectDto>> Handle(SearchCelestialQuery request, CancellationToken cancellationToken)
        {

            var searchResult = await _dataRepo.QueryAsync<CelestialObjectEntityModel>(
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
