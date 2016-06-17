using System;
using Tweak.Sources.Json;

namespace Tweak.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadSettingsFromAppSettings();
            ReadSettingsFromJsonFile();

            Console.ReadLine();
        }

        private static void ReadSettingsFromAppSettings()
        {
            var apiSettings = new ApiSettings();

            Console.WriteLine("Reading Api settings from app settings in config...");
            Console.WriteLine("Api Key: {0}", apiSettings.ApiKey);
            Console.WriteLine("Api Endpoint: {0}\n", apiSettings.Endpoint);
        }

        private static void ReadSettingsFromJsonFile()
        {
            JsonSettingsFileManager
                .AddFile("ApiSettings.json");

            var apiSettings = new ApiSettingsJson();

            Console.WriteLine("Reading Api settings from json file...");
            Console.WriteLine("Api Key: {0}", apiSettings.ApiKey);
            Console.WriteLine("Api Endpoint: {0}\n", apiSettings.Endpoint);
        }
    }
}
