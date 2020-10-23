using System;
using Astro.Inftrastructure.Serilog;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
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
                .ConfigureAppConfiguration((ctx, config) =>
                {
                    var isDevEnv = ctx.HostingEnvironment.IsDevelopment();

                    if (isDevEnv)
                    {
                        config.AddJsonFile("appsettings.dev.json", optional: false, reloadOnChange: true);
                    }

                    if (!isDevEnv)
                    {
                        var builtConfig = config.Build();

                        var azureServiceTokenProvider = new AzureServiceTokenProvider();
                        var keyVaultClient = new KeyVaultClient(
                            new KeyVaultClient.AuthenticationCallback(
                                azureServiceTokenProvider.KeyVaultTokenCallback));

                        config.AddAzureKeyVault(
                            $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                            keyVaultClient,
                            new DefaultKeyVaultSecretManager());
                    }
                })
                .UseSerilog((ctx, config) =>
                {
                    if (!ctx.HostingEnvironment.IsDevelopment())
                    {
                        var teleConfig = TelemetryConfiguration.CreateDefault();
                        teleConfig.InstrumentationKey = ctx.Configuration.GetValue<string>("APPINSIGHTS_INSTRUMENTATIONKEY");

                        config.WriteTo.ApplicationInsights(teleConfig, TelemetryConverter.Events);
                    }

                    SerilogConfiguration.CreateDefaultLogger(ctx, config);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
