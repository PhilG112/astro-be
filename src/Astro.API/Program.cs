using System;
using System.IO;
using Astro.API.Application;
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
                .AddJsonFile($"appsettings.{Constants.Environments.CurrentAspNetEnv}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (Constants.Environments.CurrentAspNetEnv == Constants.Environments.Development)
            {
                config.AddUserSecrets<Startup>();
            }

            InitLogging(config.Build());
        }

        private static void InitLogging(IConfigurationRoot configRoot)
        {
            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext();

            if (Constants.Environments.CurrentAspNetEnv == Constants.Environments.Development)
            {
                var seqServerUrl = configRoot.GetValue<string>("SeqServerUrl");
                loggerConfig.WriteTo.Seq(seqServerUrl, LogEventLevel.Verbose);
                loggerConfig.WriteTo.Console(LogEventLevel.Verbose);
                loggerConfig.WriteTo.File("log.txt", LogEventLevel.Verbose);
            }

            Log.Logger = loggerConfig.CreateLogger();
        }
    }
}
