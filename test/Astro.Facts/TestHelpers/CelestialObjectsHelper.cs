using Astro.API.Application.Stores.EntityModels;
using Astro.API.Application.Stores.EntityModels.Enums;
using System.Collections.ObjectModel;

namespace Astro.Facts.TestHelpers
{
    public static class CelestialObjectsHelper
    {
        public static CelestialEntityModel GetDefaultEntityModel()
        {
            return new CelestialEntityModel
            {
                Id = 1,
                AbsoluteMagnitude = -5.44,
                Magnitude = 8.55,
                Name = "The Andromeda Galaxy",
                ObjectType = ObjectType.Galaxy,
                Designation1 = "Messier31",
                Designation2 = "M31",
                Designation3 = "NGC224",
                Designation4 = null,
                Distances = new Collection<DistanceEntityModel>
                {
                    new DistanceEntityModel
                    {
                        CelestialObjectId = 1,
                        DistanceType = DistanceType.LightYear,
                        Value = 2500000,
                        Tolerance = 110000
                    }
                }
            };
        }
    }
}
