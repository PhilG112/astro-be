using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Astro.Integration.Celestial
{
    public class CelestialControllerTests : CelestialBase
    {
        [Fact]
        public async Task When_get_is_called_should_get_success_response()
        {
            // Act
            var response = await Client.GetAsync(ApiEndpoints.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
