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
            ReadSettingsFromAppSettingsIntoNestedType();
            ReadSettingsFromJsonFileIntoNestedType();

            Console.ReadLine();
        }

        private static void ReadSettingsFromAppSettings()
        {
            var apiSettings = new ApiSettings();

            Console.WriteLine("Reading Api settings from app settings...");
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

        private static void ReadSettingsFromAppSettingsIntoNestedType()
        {
            var apiSettings = new Api.Settings();

            Console.WriteLine("Reading Api settings from app settings into nested class...");
            Console.WriteLine("Api Key: {0}", apiSettings.ApiKey);
            Console.WriteLine("Api Endpoint: {0}\n", apiSettings.Endpoint);
        }

        private static void ReadSettingsFromJsonFileIntoNestedType()
        {
            JsonSettingsFileManager
                .AddFile("Api.Settings.json");

            var apiSettings = new ApiJson.Settings();

            Console.WriteLine("Reading Api settings from json file into nested class...");
            Console.WriteLine("Api Key: {0}", apiSettings.ApiKey);
            Console.WriteLine("Api Endpoint: {0}\n", apiSettings.Endpoint);
        }
    }
}
