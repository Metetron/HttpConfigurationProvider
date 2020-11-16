using System;
using Metetron.HttpConfigurationProvider;
using Microsoft.Extensions.Configuration;

namespace Metetron.ProviderConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new HttpConfigurationSourceSettings
            {
                AppName = "GrinderHost",
                ServerUri = "http://localhost:5000/api/appsettings",
                HostName = "dblc2035"
            };

            var config = new ConfigurationBuilder()
                .Add(new HttpConfigurationSource(settings))
                .Build();

            foreach (var item in config.AsEnumerable())
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
