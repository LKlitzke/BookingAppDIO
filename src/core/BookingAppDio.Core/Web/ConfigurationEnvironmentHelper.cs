using Microsoft.Extensions.Configuration;

namespace BookingAppDio.Core.Web
{
    public static class ConfigurationEnvironmentHelper
    {
        public static IConfiguration GetConfiguration(string basePath = null)
        {
            basePath ??= Directory.GetCurrentDirectory();
            var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{envVariable}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
