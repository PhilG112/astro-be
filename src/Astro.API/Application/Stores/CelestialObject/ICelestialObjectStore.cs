using System.Threading.Tasks;
using Astro.API.Application.Stores.EntityModels;

namespace Astro.API.Application.Stores.CelestialObject
{
    public interface ICelestialObjectStore
    {
        Task<CelestialObjectEntityModel> GetCelestialObject();
    }
}
