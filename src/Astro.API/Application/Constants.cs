using System;

namespace Astro.API.Application
{
    public static class Constants
    {
        public static class Environments
        {
            public static string CurrentAspNetEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            public static string Development = nameof(Development);
            public static string Production = nameof(Production);
        }

        public static class JwtToken
        {
            public static DateTime ExpireTime = DateTime.Now.AddHours(1);
        }
    }
}
