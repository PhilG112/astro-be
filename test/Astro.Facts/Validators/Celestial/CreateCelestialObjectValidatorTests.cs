using System;
using System.Collections.Generic;
using System.Text;
using Astro.Application.Celestial.Commands.CreateCelestialObject;
using Astro.Application.Celestial.Dtos;
using Xunit;
using FluentValidation.TestHelper;

namespace Astro.Facts.Validators.Celestial
{
    public class CreateCelestialObjectValidatorTests
    {
        private readonly CreateCelestialObjectValidator _validator;

        public CreateCelestialObjectValidatorTests()
        {
            _validator = new CreateCelestialObjectValidator();
        }

        [Fact]
        public void GivenValidObject_WhenValidating_ThenShouldNotHaveValidationError()
        {
            var command = new CreateCelestialObjectCommand
            {
                Name = "name",
                AbsoluteMagnitude = 10,
                Description = "description",
                Designation1 = "d1",
                Designation2 = "d2",
                Designation3 = "d3",
                Designation4 = "d4",
                Distance = 11,
                DistanceTolerance = 1,
                Magnitude = 20,
                ObjectType = ObjectTypeDto.Galaxy
            };

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void GivenInvalidName_WhenValidating_ThenShouldHaveError()
        {
            var command = new CreateCelestialObjectCommand
            {
                Name = "somereallystupidlongassnamethatis40+chars"
            };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("somereallystupidlongassnamekjhkjthatisallaroundtheworld40+chars")]
        public void GivenInvalidDesignation1_WhenValidating_ThenShouldHaveError(string deg1)
        {
            var command = new CreateCelestialObjectCommand
            {
                Designation1 = deg1,
            };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Designation1);
        }
    }
}
