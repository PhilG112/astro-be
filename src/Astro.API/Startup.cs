using System.Text.Json.Serialization;
using Astro.Application;
using Astro.Domain;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Astro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = Configuration["AuthOptions:Domain"];
                options.Audience = Configuration["AuthOptions:Audience"];
            });

            services.AddApplicationInsightsTelemetry(Configuration.GetValue<string>("ApplicationInsights:Key"));
            services.AddAstroApplication(Configuration);
            services.AddAstroDomain(Configuration);

            services.ConfigureApiBehaviourOptions();
            services.AddProblemDetails(Environment);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseProblemDetails();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(options => options.WithOrigins().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(config => config.MapControllers());
        }
    }
}
