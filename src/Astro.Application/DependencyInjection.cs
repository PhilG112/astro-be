using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Astro.Application.Mediator.Behaviors;
using FluentValidation;
using AutoMapper;

namespace Astro.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAstroApplication(this IServiceCollection services, IConfiguration config)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);

            AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(x => services.AddScoped(x.InterfaceType, x.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}