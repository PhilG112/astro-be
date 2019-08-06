using System.Threading.Tasks;
using Astro.API.Application.Stores.EntityModels;

namespace Astro.API.Application.Stores.Celestial
{
    public interface ICelestialStore
    {
        Task<CelestialObjectEntityModel> GetCelestialObject();
    }
}
