using System.Linq;
using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Search;
using Astro.API.Application.Stores.EntityModels;

namespace Astro.API.Application.Extensions
{
    public static class CelestialObjectExtensions
    {
        public static CelestialGetResponseModel ToResponseModel(this CelestialEntityModel model)
        {
            return new CelestialGetResponseModel
            {
                Id = model.Id,
                Name = model.Name,
                Magnitude = model.Magnitude,
                AbsoluteMagnitude = model.AbsoluteMagnitude,
                ObjectType = model.ObjectType,
                Designation1 = model.Designation1,
                Designation2 = model.Designation2,
                Designation3 = model.Designation3,
                Designation4 = model.Designation4
            };
        }
    }
}