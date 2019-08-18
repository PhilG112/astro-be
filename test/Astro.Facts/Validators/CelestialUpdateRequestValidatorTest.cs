using System.Collections.Generic;
using Astro.API.Application.Request.Update;
using Astro.API.Application.Stores.EntityModels.Enums;
using Astro.API.Application.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Astro.Facts.Validators
{
    public class CelestialUpdateRequestValidatorTest
    {
        private static readonly string _longName = "some really really really really  long name";

        [Fact]
        public void When_Name_Is_Too_Long_Then_Should_Have_Error()
        {
            var validator = new CelestialUpdateRequestValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Name, _longName)
                .WithErrorMessage("Specified 'Name' is too long.");
        }

        [Fact]
        public void When_Designation1_Is_Too_Long_Then_Should_Have_Error()
        {
            var validator = new CelestialUpdateRequestValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Designation1, _longName)
                .WithErrorMessage("Designation1 is too long");
        }

        [Fact]
        public void When_Designation2_Is_Too_Long_Then_Should_Have_Error()
        {
            var validator = new CelestialUpdateRequestValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Designation2, _longName)
                .WithErrorMessage("Designation2 is too long");
        }

        [Fact]
        public void When_Designation3_Is_Too_Long_Then_Should_Have_Error()
        {
            var validator = new CelestialUpdateRequestValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Designation3, _longName)
                .WithErrorMessage("Designation3 is too long");
        }

        [Fact]
        public void When_Designation4_Is_Too_Long_Then_Should_Have_Error()
        {
            var validator = new CelestialUpdateRequestValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Designation4, _longName)
                .WithErrorMessage("Designation4 is too long");
        }

        [Fact]
        public void When_Distances_Is_Null_Then_Should_Have_Error()
        {
            var obj = new CelestialUpdateRequestModel
            {
                Name = "Test",
                Magnitude = 1.1,
                AbsoluteMagnitude = 1.1,
                Description = "test",
                Designation1 = "test",
                Designation2 = "test",
                Designation3 = "test",
                Designation4 = "test",
                ObjectType = ObjectType.Galaxy,
                Distances = null
            };

            var validator = new CelestialUpdateRequestValidator();
            var result = validator.Validate(obj);

            Assert.True(result.Errors.Count > 0);
            Assert.Equal("Celestial object must have at least 1 distance", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void When_Distances_Is_Empty_Then_Should_Have_Error()
        {
            var obj = new CelestialUpdateRequestModel
            {
                Name = "Test",
                Magnitude = 1.1,
                AbsoluteMagnitude = 1.1,
                Description = "test",
                Designation1 = "test",
                Designation2 = "test",
                Designation3 = "test",
                Designation4 = "test",
                ObjectType = ObjectType.Galaxy,
                Distances = new List<DistanceUpdateRequestModel>()
            };

            var validator = new CelestialUpdateRequestValidator();
            var result = validator.Validate(obj);

            Assert.True(result.Errors.Count > 0);
            Assert.Equal("Celestial object must have at least 1 distance", result.Errors[0].ErrorMessage);
        }
    }
}
