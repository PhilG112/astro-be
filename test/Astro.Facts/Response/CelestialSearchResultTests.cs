using System;
using System.Collections.Generic;
using Astro.API.Application.Response.Search;
using FluentAssertions;
using Xunit;

namespace Astro.Facts.Response
{
    public class CelestialSearchResultTests
    {
        [Fact]
        public void Result_Object_HasException_Should_Be_True_If_Exception_Exists()
        {
            var expected = new CelestialSearchQueryResult(new Exception());

            expected.HasException.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_HasException_Should_Be_False_If_Exception_Not_Exists()
        {
            var expected = new CelestialSearchQueryResult(ex: null);

            expected.HasException.Should().BeFalse();
        }

        [Fact]
        public void Result_Object_NotFound_Should_Be_True_If_Given_True()
        {
            var expected = new CelestialSearchQueryResult(true);

            expected.NotFound.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_NotFound_Should_Be_False_If_Given_False()
        {
            var expected = new CelestialSearchQueryResult(false);

            expected.NotFound.Should().BeFalse();
        }

        [Fact]
        public void Result_Object_Result_Should_Not_Be_Null_With_Valid_Value()
        {
            var models = new List<CelestialSearchQueryResultModel>
            {
                new CelestialSearchQueryResultModel { Id = 1, Designation1 = "Desg1" },
                new CelestialSearchQueryResultModel { Id = 2, Designation1 = "Desg1" }
            };

            var expected = new CelestialSearchQueryResult(models);

            expected.Results.Should().NotBeNullOrEmpty();
        }
    }
}
