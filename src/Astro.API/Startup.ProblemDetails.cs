using System;
using Astro.API.ProblemDetailObjects;
using Astro.Inftrastructure.Exceptions;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Astro.API
{
    public static class StartupProblemDetails
    {
        public static IServiceCollection AddProblemDetails(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (ctx, ex) => env.IsDevelopment();

                options.Map<NotFoundException>(ex => new NotFoundProblemDetails(ex));
                options.Map<ValidationException>(ex => new BadRequestProblemDetails(ex));

                options.Map<Exception>(ex => new ServerErrorProblemDetails(ex));
            });

            return services;
        }
    }
}