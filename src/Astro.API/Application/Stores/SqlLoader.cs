using System;
using System.IO;
using System.Reflection;

namespace Astro.API.Application.Stores
{
    public static class SqlLoader
    {
        public static string GetSql(string sqlResourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(sqlResourceName);
            if (stream == null)
            {
                throw new Exception($"Resource {sqlResourceName} not found in {assembly.FullName}." +
                    $"Valid resources are: {string.Join(", ", assembly.GetManifestResourceNames())}.");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
