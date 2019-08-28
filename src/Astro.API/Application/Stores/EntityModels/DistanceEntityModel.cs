﻿using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Stores.EntityModels
{
    public class DistanceEntityModel
    {
        public int CelestialObjectId { get; set; }

        public DistanceType DistanceType { get; set; }

        public double Value { get; set; }

        public double Tolerance { get; set; }
    }
}