using FluentValidation;

namespace Astro.Application.Celestial.Commands.CreateCelestialObject
{
    public class CreateCelestialObjectValidator : AbstractValidator<CreateCelestialObjectCommand>
    {
        public CreateCelestialObjectValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Name is too long.");
            RuleFor(x => x.Designation1).NotEmpty().MaximumLength(60).WithMessage("Designation1 is too long");
            RuleFor(x => x.Designation2).MaximumLength(60).WithMessage("Designation2 is too long");
            RuleFor(x => x.Designation3).MaximumLength(60).WithMessage("Designation3 is too long");
            RuleFor(x => x.Designation4).MaximumLength(60).WithMessage("Designation4 is too long");
            RuleFor(x => x.Distance).GreaterThan(0).WithMessage("Distance must be greater than 0");
            RuleFor(x => x.Magnitude).GreaterThan(0).WithMessage("Magnitude must be greater than 0");
            RuleFor(x => x.ObjectType).NotNull().WithMessage("ObjectType must not be null");
        }
    }
}
