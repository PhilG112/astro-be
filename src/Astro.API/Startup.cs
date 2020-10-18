using System.Text;
using System.Text.Json.Serialization;
using Astro.API.Application.Services.Upload;
using Astro.Application;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                var secretKey = Configuration.GetValue<string>("AppSettings:SecretKey");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // ValidAudience = "https://localhost:5001",
                    // ValidIssuer = "https://localhost:5001",
                    // LifetimeValidator = new LifetimeValidator fix this lol
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                };
            });

            services.AddApplicationInsightsTelemetry(Configuration.GetValue<string>("ApplicationInsights:Key"));
            services.AddAstroApplication(Configuration);
            services.ConfigureApiBehaviourOptions();
            services.AddProblemDetails(Environment);
            services.AddCelestialStore(Configuration);
            services.AddBlobStorageClient(Configuration);
            services.AddSingleton<IUploadService, UploadService>();
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
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseBlobStorageClient();
            app.UseEndpoints(config => config.MapControllers());
        }

        protected virtual void ConfigureTestServices(IServiceCollection services)
        {
            // DEVNOTE: To override in test projects where services can replaced with mocked instances.
        }
    }
}
