using System;
using System.Threading;
using System.Threading.Tasks;
using Astro.Inftrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Astro.Application.Mediator.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            try
            {
                return await next();
            }
            catch (NotFoundException ex)
            {
                ex.Data.Add("InstanceId", Guid.NewGuid().ToString());

                _logger.LogInformation(ex, "Resource not found for request: {requestName}", requestName);

                throw;
            }
            catch (Exception ex)
            {
                ex.Data.Add("InstanceId", Guid.NewGuid().ToString());

                _logger.LogError(ex, "Unexpected error for request: {requestName}. Check details.", requestName);

                throw;
            }
        }
    }
}