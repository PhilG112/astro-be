﻿using System;
using Astro.API.Application.Response.Create;
using FluentAssertions;
using Xunit;

namespace Astro.Facts.Response
{
    public class CelestialCreateResultTests
    {
        [Fact]
        public void Result_Object_HasException_Should_Be_True_If_Exception_Exists()
        {
            var expected = new CelestialCreateResult(new Exception());

            expected.HasException.Should().BeTrue();
        }

        [Fact]
        public void Result_Object_HasException_Should_Be_False_If_Exception_Not_Exists()
        {
            var expected = new CelestialCreateResult(ex: null);

            expected.HasException.Should().BeFalse();
        }

        [Fact]
        public void Result_Object_Result_Should_Not_Be_Null_With_Valid_Value()
        {
            var expected = new CelestialCreateResult(1);

            expected.Result.Should().Be(1);
        }
    }
}