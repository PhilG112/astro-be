using FluentValidation;

namespace Astro.Application.Celestial.Queries.GetCelestialById
{
    public class GetCelestialByIdValidator : AbstractValidator<GetCelestialByIdQuery>
    {
        public GetCelestialByIdValidator()
        {
            RuleFor(x => x.CelestialId).GreaterThan(0);
        }
    }
}
