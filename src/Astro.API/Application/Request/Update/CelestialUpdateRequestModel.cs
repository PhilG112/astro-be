﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Request.Update
{
    public class CelestialUpdateRequestModel
    {
        public CelestialUpdateRequestModel()
        {
            Distances = new Collection<DistanceUpdateRequestModel>();
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

        public string Description { get; set; }

        public ICollection<DistanceUpdateRequestModel> Distances { get; set; }
    }
}
