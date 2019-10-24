using Astro.API.Application;
using Astro.API.Application.Stores.Celestial;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.API
{
    public static class StartupCelestialStore
    {
        public static IServiceCollection AddCelestialStore(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connString = config.GetConnectionString(Constants.ConnectionStrings.Astro);

            services.AddSingleton<ICelestialStore>(_ => new CelestialStore(connString));
            return services;
        }
    }
}
