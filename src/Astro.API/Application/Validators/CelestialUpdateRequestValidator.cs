using Astro.API.Application.Request.Update;
using FluentValidation;

namespace Astro.API.Application.Validators
{
    public class CelestialUpdateRequestValidator : AbstractValidator<CelestialUpdateRequestModel>
    {
        public CelestialUpdateRequestValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Specified 'Name' is too long.");
            RuleFor(x => x.Designation1).MaximumLength(30).WithMessage("Designation1 is too long");
            RuleFor(x => x.Designation2).MaximumLength(30).WithMessage("Designation2 is too long");
            RuleFor(x => x.Designation3).MaximumLength(30).WithMessage("Designation3 is too long");
            RuleFor(x => x.Designation4).MaximumLength(30).WithMessage("Designation4 is too long");
        }
    }
}
