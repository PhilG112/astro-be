using System;
using System.IO;
using Astro.API.Application;
using Astro.Inftrastructure.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Astro.API
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            try
            {
                webHost.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unable to start host, check application configuartion.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Constants.Environments.CurrentAspNetEnv}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

                if (Constants.Environments.CurrentAspNetEnv == Constants.Environments.Development)
                {
                    builder.AddUserSecrets<Startup>();
                }
            })
            .UseSerilog((ctx, logConfig) => ctx.CreateDefaultLogger(logConfig))
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}
