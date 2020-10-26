using System;
using System.Threading;
using System.Threading.Tasks;
using Astro.Infrastructure.Exceptions;
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

                Log($"Resource not found for request: {requestName}", LogLevel.Error, ex);

                throw;
            }
            catch (ResourceConflictException ex)
            {
                ex.Data.Add("InstanceId", Guid.NewGuid().ToString());
                Log($"Conflicted resource for request {requestName}", LogLevel.Error, ex);

                throw;
            }
            catch (Exception ex)
            {
                ex.Data.Add("InstanceId", Guid.NewGuid().ToString());
                Log($"Unexpected error for request: {requestName}. Check details.", LogLevel.Error, ex);

                throw;
            }
        }

        private void Log(string message, LogLevel logLevel, Exception ex)
        {
            _logger.Log(
                logLevel,
                ex,
                message);
        }
    }
}