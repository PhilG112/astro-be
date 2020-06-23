using Astro.Abstractions.Data;
using Astro.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.Domain
{
    public static class DependencyInjection
    {
        private const string connStringName = "Astro";

        public static IServiceCollection AddAstroDomain(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ISqlConnectionFactory>(_ =>
            {
                var connString = config.GetConnectionString(connStringName);
                return new SqlConnectionFactory(connString);
            });

            return services;
        }
    }
}