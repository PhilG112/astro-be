using Astro.Application.Celestial.Dtos;
using System.Collections.Generic;

namespace Astro.Application.Celestial.Queries.SearchCelestial
{
    public class SearchCelestialQuery : IQuery<IEnumerable<CelestialObjectDto>>
    {
        public string SearchText { get; }

        public SearchCelestialQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
