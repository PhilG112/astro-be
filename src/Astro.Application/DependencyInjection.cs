using System.Reflection;
using Astro.Abstractions;
using Astro.Application.Auth;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Astro.Domain;
using Astro.Application.Mediator.Behaviors;

namespace Astro.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAstroApplication(this IServiceCollection services, IConfiguration config)
        {
            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);
            services.AddScoped<IJwtTokenGenerator>(_ => new JwtTokenGenerator(appSettings));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddAstroDomain(config);

            return services;
        }
    }
}