using Astro.API;
using Astro.Integration.Celestial;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.Integration
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration config)
            : base(config)
        { }

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            services.AddSingleton(CelestialStoreMock.GetStoreMock());
        }
    }
}
