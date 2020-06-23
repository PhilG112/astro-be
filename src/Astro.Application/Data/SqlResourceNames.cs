namespace Astro.Application.Data
{
    internal static class SqlResourceNames
    {
        public const string BaseResourceName = "Astro.Application.Data.SqlScripts";

        internal static class User
        {
            public static string User_Get = $"{BaseResourceName}.{nameof(User)}.Get_User.sql";
        }

        internal static class CelestialObjects
        {
            private const string BaseResourceName = "Astro.API.Properties.Sql.CelestialObjects";
            public static string CelestialObject_Get = $"{BaseResourceName}.CelestialObject_Get.sql";
            public static string CelestialObject_Search = $"{BaseResourceName}.CelestialObject_Search.sql";
            public static string CelestialObject_Create = $"{BaseResourceName}.CelestialObject_Create.sql";
            public static string CelestialObject_Update = $"{BaseResourceName}.CelestialObject_Update.sql";
            public static string CelestialObject_Delete = $"{BaseResourceName}.CelestialObject_Delete.sql";
        }
    }
}