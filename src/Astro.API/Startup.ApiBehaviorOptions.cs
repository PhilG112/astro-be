using System;
using System.Linq;
using Astro.API.ProblemDetailObjects;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Astro.API
{
    public static class StartupApiBehaviourOptions
    {
        public static IServiceCollection ConfigureApiBehaviourOptions(this IServiceCollection services)
        {
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values
                        .SelectMany(x => x.Errors.Select(e => new ValidationFailure(null, e.ErrorMessage))).ToList();

                    var ex = new ValidationException(errors);

                    ex.Data.Add("InstanceId", Guid.NewGuid().ToString());

                    var requestPath = context.HttpContext.Request.Path.Value;
                    logger.Information(ex, "Bad request at {requestPath}.", requestPath);

                    return new BadRequestObjectResult(new BadRequestProblemDetails(ex));
                };
            });

            return services;
        }
    }
}
