using Astro.Inftrastructure.Serilog.Enrichers;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace Astro.Inftrastructure.Serilog
{
    public static class SerilogConfiguration
    {
        public static void CreateDefaultLogger(
            HostBuilderContext context,
            LoggerConfiguration loggerConfiguration)
        {
            _ = loggerConfiguration
                .ReadFrom.Configuration(context.Configuration)
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .Enrich.With<InstanceIdEnricher>();
        }
    }
}