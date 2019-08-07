using System.Threading.Tasks;
using Astro.API.Application.Response;

namespace Astro.API.Application.Stores.Celestial
{
    public interface ICelestialStore
    {
        Task<CelestialGetResult> GetCelestialObject();
    }
}
