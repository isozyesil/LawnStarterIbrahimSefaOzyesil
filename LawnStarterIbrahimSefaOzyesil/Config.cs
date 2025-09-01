using Microsoft.Extensions.Configuration;
using System.IO;

namespace LawnStarterIbrahimSefaOzyesil.Assembly
{
    public static class Config
    {
        private static IConfigurationRoot configuration;
        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }
        public static string BaseUrl => configuration["AppSettings:BaseUrl"];
        public static string Browser => configuration["AppSettings:Browser"];
        public static int DefaultTimeout => int.Parse(configuration["AppSettings:DefaultTimeoutSeconds"]);
    }
}
