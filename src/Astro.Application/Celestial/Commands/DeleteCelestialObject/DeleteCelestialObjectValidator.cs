using FluentValidation;

namespace Astro.Application.Celestial.Commands.DeleteCelestialObject
{
    public class DeleteCelestialObjectValidator : AbstractValidator<DeleteCelestialObjectCommand>
    {
        public DeleteCelestialObjectValidator()
        {
            RuleFor(x => x.CelestialObjectId).GreaterThan(0).WithMessage("Message must be greater than 0");
        }
    }
}
