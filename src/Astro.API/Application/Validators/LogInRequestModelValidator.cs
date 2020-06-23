using Astro.API.Application.Request.Login;
using FluentValidation;

namespace Astro.API.Application.Validators
{
    public class LogInRequestModelValidator : AbstractValidator<LogInRequestModel>
    {
        public LogInRequestModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Invalid username or password");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Invalid username or password");
        }
    }
}
