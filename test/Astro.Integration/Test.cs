using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Astro.Integration
{
    public class Test : IClassFixture<WebApplicationFactory<Astro.API.Startup>>
    {
        private readonly WebApplicationFactory<Astro.API.Startup> _factory;

        public Test(WebApplicationFactory<Astro.API.Startup> factory)
        {
            _factory = factory;
        }
    }
}