using Microsoft.Extensions.Configuration;

namespace PGDemo.Common
{
    public static class ConfigHelper
    {
        private static IConfiguration _configuration;

        public static void Init(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetValue(string key)
        {
            return _configuration.GetValue<string>(key);
        }

        public static T GetValue<T>(string key)
        {
            return _configuration.GetValue<T>(key);
        }
    }
}
