using Astro.API.Application.Extensions;
using Astro.Facts.TestHelpers;
using System.Linq;
using Xunit;

namespace Astro.Facts.Extensions
{
    public class CelestialObjectExtensionTests
    {
        [Fact]
        public void ToResponseModel_Extension_Should_Map_Correctly()
        {
            // Arrange
            var expected = CelestialObjectsHelper.GetDefaultEntityModel();

            // Act
            var actual = expected.ToResponseModel();

            // Assert
            Assert.Equal(expected.AbsoluteMagnitude, actual.AbsoluteMagnitude);
            Assert.Equal(expected.Magnitude, actual.Magnitude);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.ObjectType, actual.ObjectType);
            Assert.Equal(expected.Designation1, actual.Designation1);
            Assert.Equal(expected.Designation2, actual.Designation2);
            Assert.Equal(expected.Designation3, actual.Designation3);
            Assert.Equal(expected.Designation4, actual.Designation4);
            Assert.Equal(expected.Distances.First().DistanceType, actual.Distances.First().DistanceType);
            Assert.Equal(expected.Distances.First().Value, actual.Distances.First().Value);
            Assert.Equal(expected.Distances.First().Tolerance, actual.Distances.First().Tolerance);
        }
    }
}
