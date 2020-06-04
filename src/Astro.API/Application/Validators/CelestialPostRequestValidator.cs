using Astro.API.Application.Request.Post;
using FluentValidation;

namespace Astro.API.Application.Validators
{
    public class CelestialPostRequestValidator : AbstractValidator<CelestialPostRequestModel>
    {
        public CelestialPostRequestValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Specified 'Name' is too long.");
            RuleFor(x => x.Designation1).MaximumLength(30).WithMessage("Designation1 is too long");
            RuleFor(x => x.Designation2).MaximumLength(30).WithMessage("Designation2 is too long");
            RuleFor(x => x.Designation3).MaximumLength(30).WithMessage("Designation3 is too long");
            RuleFor(x => x.Designation4).MaximumLength(30).WithMessage("Designation4 is too long");
            RuleFor(x => x.Distance).GreaterThan(0).WithMessage("Distance must be greater than 0");
        }
    }
}
