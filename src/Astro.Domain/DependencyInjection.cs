using Astro.Abstractions.Clients;
using Astro.Abstractions.Data;
using Astro.Domain.Clients;
using Astro.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.Domain
{
    public static class DependencyInjection
    {
        private const string sqlConnStringName = "Astro";
        private const string storageAccConnStringName = "StorageAccount";

        public static IServiceCollection AddAstroDomain(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ISqlConnectionFactory>(_ =>
            {
                var connString = config.GetConnectionString(sqlConnStringName);
                return new SqlConnectionFactory(connString);
            });

            services.AddSingleton<IBlobStorageClient>(_ =>
            {
                var connString = config.GetConnectionString(storageAccConnStringName);

                return new BlobStorageClient(connString);
            });

            services.AddTransient<ISqlDataRepository>(provider =>
            {
                var factory = provider.GetRequiredService<ISqlConnectionFactory>();

                return new DapperDataRepository(factory);
            });

            return services;
        }
    }
}