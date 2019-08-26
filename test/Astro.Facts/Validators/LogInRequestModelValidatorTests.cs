using Astro.API.Application.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Astro.Facts.Validators
{
    public class LogInRequestModelValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void When_UserName_Is_NullOrEmpty_Then_Should_Have_Validation_Error(string userName)
        {
            var validator = new LogInRequestModelValidator();
            validator.ShouldHaveValidationErrorFor(x => x.UserName, userName)
                .WithErrorMessage("Invalid username or password");
        }

        [Fact]
        public void When_UserName_Is_Not_NullOrEmpty_Then_Should_Not_Have_Validation_Error()
        {
            var validator = new LogInRequestModelValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.UserName, "John Doe");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void When_Password_Is_NullOrEmpty_Then_Should_Have_Validation_Error(string password)
        {
            var validator = new LogInRequestModelValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Password, password)
                .WithErrorMessage("Invalid username or password");
        }

        [Fact]
        public void When_Password_Is_Not_NullOrEmpty_Then_Should_Not_Have_Validation_Error()
        {
            var validator = new LogInRequestModelValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.UserName, "password123");
        }
    }
}
