using System.Linq;
using System.Threading.Tasks;
using Astro.API.Application;
using Astro.API.Application.Clients;
using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder UseBlobStorageClient(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var c = serviceScope.ServiceProvider.GetRequiredService<BlobStorageClient>();

            Task.WaitAll(c.InitBlob().ToArray());
            return app;
        }
    }
}