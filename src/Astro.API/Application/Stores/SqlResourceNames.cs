namespace Astro.API.Application.Stores
{
    public static class SqlResourceNames
    {
        public static class CelestialObject
        {
            public static readonly string BaseResourcename = "Astro.API.Properties.Sql.CelestialObjects";
            public static readonly string CelestialObject_Get = $"{BaseResourcename}.CelestialObject_Get.sql";
            public static readonly string CelestialObject_Insert = $"{BaseResourcename}.CelstialObject_Insert.sql";
        }
    }
}
