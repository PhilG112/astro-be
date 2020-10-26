using Astro.Application.Celestial.Dtos;

namespace Astro.Application.Celestial.Queries.GetCelestialById
{
    public class GetCelestialByIdQuery : IQuery<CelestialObjectDto>
    {
        public GetCelestialByIdQuery(int celestialId)
        {
            CelestialId = celestialId;
        }

        public int CelestialId { get; }
    }
}
