using Astro.API.Application.Extensions;
using Astro.API.Application.Response.Get;
using Astro.Facts.TestHelpers;
using FluentAssertions;
using System;
using Xunit;

namespace Astro.Facts.Response
{
    public class CelestialGetResultTests
    {
        [Fact]
        public void Result_Object_HasException_Should_Be_True_If_Exception_Exists()
        {
            var expected = new CelestialGetResult(new Exception());

            expected.HasException.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_HasException_Should_Be_False_If_Exception_Not_Exists()
        {
            var expected = new CelestialGetResult(ex: null);

            expected.HasException.Should().BeFalse();
        }

        [Fact]
        public void Result_Object_NotFound_Should_Be_True_If_Given_True()
        {
            var expected = new CelestialGetResult(true);

            expected.NotFound.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_NotFound_Should_Be_False_If_Given_False()
        {
            var expected = new CelestialGetResult(false);

            expected.NotFound.Should().BeFalse();
        }

        [Fact]
        public void Result_Object_Result_Should_Not_Be_Null_With_Valid_Value()
        {
            var model = CelestialObjectsHelper.GetDefaultEntityModel().ToResponseModel();
            var expected = new CelestialGetResult(model);

            expected.Result.Should().NotBeNull();
        }
    }
}