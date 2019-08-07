using System.Collections.Generic;
using System.Collections.ObjectModel;
using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Response
{
    public class CelestialGetResponseModel
    {
        public CelestialGetResponseModel()
        {
            Distances = new Collection<DistanceGetResponseModel>();
        }

        public ObjectType ObjectType { get; set; }

        public decimal Magnitude { get; set; }

        public decimal AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }

        public ICollection<DistanceGetResponseModel> Distances { get; set; }
    }
}
