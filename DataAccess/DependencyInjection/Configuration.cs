using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace DataAccess.DependencyInjection
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder();
                try
                {
                    builder.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../ErhasTestCase/ErhasTestCase"))
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                }
                catch
                {
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                }

                IConfigurationRoot configuration = builder.Build();
                return configuration.GetConnectionString("SqlServer");
            }
        }
    }
}
