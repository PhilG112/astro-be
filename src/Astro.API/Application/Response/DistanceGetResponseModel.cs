using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Response
{
    public class DistanceGetResponseModel
    {
        public DistanceType DistanceType { get; set; }

        public decimal Value { get; set; }

        public decimal Tolerance { get; set; }
    }
}
