using Astro.API.Application;
using Astro.API.Application.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.API
{
    public static class StartupBlobStorage
    {
        public static IServiceCollection AddBlobStorageClient(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connString = config.GetConnectionString(Constants.ConnectionStrings.StorageAccount);

            services.AddSingleton(_ => new BlobStorageClient(connString));

            return services;
        }
    }
}
