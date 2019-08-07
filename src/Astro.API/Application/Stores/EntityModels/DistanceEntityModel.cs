using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Stores.EntityModels
{
    public class DistanceEntityModel
    {
        public int CelestialObjectId { get; set; }

        public DistanceType DistanceType { get; set; }

        public decimal Value { get; set; }

        public decimal Tolerance { get; set; }
    }
}
