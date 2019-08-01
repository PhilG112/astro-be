using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Astro.API
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Init();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unable to start host, check application configuartion");
                return 1;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }

        private static void Init()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            InitLogging(config.Build());
        }

        private static void InitLogging(IConfigurationRoot configRoot)
        {
            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(LogEventLevel.Verbose)
                .WriteTo.File("log.txt", LogEventLevel.Verbose);

            var seqServerUrl = configRoot.GetValue<string>("SeqServerUrl");
            loggerConfig.WriteTo.Seq(seqServerUrl, LogEventLevel.Information);

            Log.Logger = loggerConfig.CreateLogger();
        }
    }
}
