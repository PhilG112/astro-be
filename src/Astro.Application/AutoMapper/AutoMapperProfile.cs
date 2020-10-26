using Astro.Application.Celestial.Dtos;
using Astro.Application.EntityModels;
using Astro.Application.EntityModels.Enums;
using AutoMapper;

namespace Astro.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CelestialObjectEntityModel, CelestialObjectDto>();
            CreateMap<ObjectType, ObjectTypeDto>();
        }
    }
}
