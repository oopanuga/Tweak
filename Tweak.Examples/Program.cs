using Tweak.Sources.Json;

namespace Tweak.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSettingsFileStore
                .AddFile("WebsiteSettings.json");
                
            var setting = new WebSettings();
            var hey = setting.Name;
            var hey2 = setting.Url;
            var id = setting.Id;
        }
    }
}
