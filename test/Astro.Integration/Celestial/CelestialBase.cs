namespace Astro.Integration.Celestial
{
    public class CelestialBase : TestBase
    {
        protected static class ApiEndpoints
        {
            public static string Get(int id) => $"{ApiUrlBase}/{id}";
        }
    }
}
