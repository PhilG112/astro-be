namespace Astro.API.Application.Stores
{
    public static class SqlResourceNames
    {
        public static class CelestialObjects
        {
            private const string BaseResourceName = "Astro.API.Properties.Sql.CelestialObjects";
            public static readonly string CelestialObject_Get = $"{BaseResourceName}.CelestialObject_Get.sql";
            public static readonly string CelestialObject_Search = $"{BaseResourceName}.CelestialObject_Search.sql";
            public static readonly string CelestialObject_Create = $"{BaseResourceName}.CelestialObject_Create.sql";
            public static readonly string CelestialObject_Update = $"{BaseResourceName}.CelestialObject_Update.sql";
            public static readonly string CelestialObject_Delete = $"{BaseResourceName}.CelestialObject_Delete.sql";
        }

        public static class Distances
        {
            private const string BaseResourceName = "Astro.API.Properties.Sql.Distances";
            public static readonly string Distances_Get = $"{BaseResourceName}.Distances_Get.sql";
            public static readonly string Distances_Create = $"{BaseResourceName}.Distances_Create.sql";
            public static readonly string Distances_Update = $"{BaseResourceName}.Distances_Update.sql";
        }
    }
}
