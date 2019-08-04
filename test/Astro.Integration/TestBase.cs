using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Net.Http;

namespace Astro.Integration
{
    public class TestBase : IDisposable
    {
        private readonly TestServer _server;

        protected HttpClient Client { get; }

        protected TestBase()
        {
            var builder = WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .UseSerilog()
                .UseStartup<TestStartup>();

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
