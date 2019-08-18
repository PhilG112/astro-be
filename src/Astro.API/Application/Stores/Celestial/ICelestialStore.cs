using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Response.Create;
using Astro.API.Application.Response.Delete;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Search;
using Astro.API.Application.Response.Update;

namespace Astro.API.Application.Stores.Celestial
{
    public interface ICelestialStore
    {
        Task<CelestialGetResult> GetCelestialObject(int id);

        Task<CelestialSearchQueryResult> SearchCelestialObject(string searchText);

        Task<CelestialCreateResult> CreateCelestialObject(CelestialPostRequestModel request);

        Task<CelestialUpdateResult> UpdateCelestialObject(CelestialUpdateRequestModel request);

        Task<CelestialDeleteResult> DeleteCelestialObject(int id);
    }
}
