using Astro.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astro.Integration
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration config)
            : base(config)
        { }

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
        }
    }
}
