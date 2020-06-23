using System;
using System.IO;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

namespace Astro.DbUp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets(Assembly.GetExecutingAssembly())
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                #if DEBUG
                Console.ReadKey();
                #endif
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            #if DEBUG
            Console.ReadKey();
            #endif
        }
    }
}
