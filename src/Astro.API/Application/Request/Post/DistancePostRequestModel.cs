﻿using Astro.API.Application.Stores.EntityModels.Enums;

namespace Astro.API.Application.Request.Post
{
    public class DistancePostRequestModel
    {
        public DistanceType DistanceType { get; set; }

        public double Value { get; set; }

        public double Tolerance { get; set; }
    }
}
