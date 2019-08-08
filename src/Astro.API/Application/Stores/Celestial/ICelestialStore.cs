using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Search;

namespace Astro.API.Application.Stores.Celestial
{
    public interface ICelestialStore
    {
        Task<CelestialGetResult> GetCelestialObject(int id);

        Task<CelestialSearchQueryResult> SearchCelestialObject(string searchText);

        Task<int> CreateCelestialObject(CelestialPostRequestModel request);
    }
}
