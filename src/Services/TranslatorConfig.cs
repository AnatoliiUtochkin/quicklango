using System.IO;
using Microsoft.Extensions.Configuration;

namespace QuickLingo.Services
{
    public static class TranslatorConfig
    {
        private static IConfigurationRoot Configuration { get; }

        static TranslatorConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string TranslatorKey => Configuration["AzureTranslator:TranslatorKey"];
        public static string TranslatorEndpoint => Configuration["AzureTranslator:TranslatorEndpoint"];
        public static string TranslatorRegion => Configuration["AzureTranslator:TranslatorRegion"];
    }
}
