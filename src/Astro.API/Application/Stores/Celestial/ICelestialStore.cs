using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Response.Delete;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Post;
using Astro.API.Application.Response.Search;
using Astro.API.Application.Response.Update;

namespace Astro.API.Application.Stores.Celestial
{
    public interface ICelestialStore
    {
        Task<CelestialGetResult> GetCelestialObjectAsync(int celestialObjectId);

        Task<CelestialSearchQueryResult> SearchCelestialObjectAsync(string searchText);

        Task<CelestialPostResult> CreateCelestialObjectAsync(CelestialPostRequestModel request);

        Task<CelestialUpdateResult> UpdateCelestialObjectAsync(CelestialUpdateRequestModel request, int celestialObjectId);

        Task<CelestialDeleteResult> DeleteCelestialObjectAsync(int celestialObjectId);
    }
}
