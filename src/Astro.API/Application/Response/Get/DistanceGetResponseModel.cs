using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Response.Get
{
    public class DistanceGetResponseModel
    {
        public int CelestialObjectId { get; set; }

        public DistanceType DistanceType { get; set; }

        public double Value { get; set; }

        public double Tolerance { get; set; }
    }
}
