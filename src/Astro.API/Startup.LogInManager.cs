using Astro.API.Application;
using Astro.API.Application.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astro.API
{
    public static class StartupLogInManager
    {
        public static IServiceCollection AddLogInManager(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connString = config.GetConnectionString(Constants.ConnectionStrings.Astro);
            var secretKey = config.GetValue<string>("AppSecret");

            services.AddSingleton<ILogInManager>(_ => new LogInManager(connString, secretKey));
            return services;
        }
    }
}
