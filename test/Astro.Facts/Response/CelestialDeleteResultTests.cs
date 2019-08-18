using System;
using Astro.API.Application.Response.Delete;
using FluentAssertions;
using Xunit;

namespace Astro.Facts.Response
{
    public class CelestialDeleteResultTests
    {
        [Fact]
        public void Result_Object_HasException_Should_Be_True_If_Exception_Exists()
        {
            var expected = new CelestialDeleteResult(new Exception());

            expected.HasException.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_HasException_Should_Be_False_If_Exception_Not_Exists()
        {
            var expected = new CelestialDeleteResult(ex: null);

            expected.HasException.Should().BeFalse();
        }
    }
}
