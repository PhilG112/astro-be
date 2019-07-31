using System;
using System.IO;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace Astro.DbUp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connString = config.GetConnectionString("Astro");

            EnsureDatabase.For.SqlDatabase(connString);

            var upgrader = DeployChanges
                .To
                .SqlDatabase(connString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(result.Error);
                ResetColor();

#if DEBUG
                ReadKey();
#endif
                return;
            }

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Success!");
            ResetColor();

#if DEBUG
            ReadKey();
#endif
        }
    }
}
