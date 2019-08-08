using System.Collections.Generic;
using System.Collections.ObjectModel;
using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Response.Get
{
    public class CelestialGetResponseModel
    {
        public CelestialGetResponseModel()
        {
            Distances = new Collection<DistanceGetResponseModel>();
        }

        public int Id { get; set; }

        public ObjectType ObjectType { get; set; }

        public double Magnitude { get; set; }

        public double AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }

        public ICollection<DistanceGetResponseModel> Distances { get; set; }
    }
}
