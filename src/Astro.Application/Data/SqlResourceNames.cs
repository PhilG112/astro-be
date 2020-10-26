namespace Astro.Application.Data
{
    internal static class SqlResourceNames
    {
        public const string BaseResourceName = "Astro.Application.Data.SqlScripts";

        internal static class CelestialObjects
        {
            public static string CelestialObject_Get = $"{BaseResourceName}.CelestialObjects.CelestialObject_Get.sql";
            public static string CelestialObject_Search = $"{BaseResourceName}.CelestialObjects.CelestialObject_Search.sql";
            public static string CelestialObject_Create = $"{BaseResourceName}.CelestialObjects.CelestialObject_Create.sql";
            public static string CelestialObject_Update = $"{BaseResourceName}.CelestialObjects.CelestialObject_Update.sql";
            public static string CelestialObject_Delete = $"{BaseResourceName}.CelestialObjects.CelestialObject_Delete.sql";
        }
    }
}