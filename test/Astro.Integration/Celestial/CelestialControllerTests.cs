using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Astro.Integration.Celestial
{
    public class CelestialControllerTests : CelestialBase
    {
        [Fact]
        public async Task When_Get_Is_Called_Without_JWT_Then_Should_Be_Unauthorized_Response()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient().GetAsync(ApiEndpoints.Get(1));

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}
