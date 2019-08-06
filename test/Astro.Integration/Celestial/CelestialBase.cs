namespace Astro.Integration.Celestial
{
    public class CelestialBase : TestBase
    {
        private const string UrlBase = "celestial";

        protected static class ApiEndpoints
        {
            public static string Get => UrlBase;
        }
    }
}
