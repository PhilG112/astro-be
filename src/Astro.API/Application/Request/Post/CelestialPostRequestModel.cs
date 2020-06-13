﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Request.Post
{
    public class CelestialPostRequestModel
    {
        public ObjectType ObjectType { get; set; }

        public double Magnitude { get; set; }

        public double AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }

        public string Description { get; set; }

        public double Distance { get; set; }

        public double DistanceTolerance { get; set; }
    }
}
