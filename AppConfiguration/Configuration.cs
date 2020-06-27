using Microsoft.Extensions.Configuration;
using System;

namespace AppConfiguration
{
    public static class Configuration
    {
        public static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetConfiguration(string key) => _configuration.GetValue<string>(key);

        public static string GetConfiguration(IConfigurationSection configSection, string key) => configSection.GetValue<string>(key);

        public static IConfigurationSection GetSection(string key) => _configuration.GetSection(key);


        public static string ApiBaseUrl
        {
            get
            {
                var result = GetConfiguration("ApiBaseUrl");
                if (!string.IsNullOrEmpty(result)) return result;

                throw new Exception("Appsetting.json doesn't contain ApiBaseUrl");

            }
        }
    }
}
