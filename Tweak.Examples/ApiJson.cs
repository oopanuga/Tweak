using Tweak.Sources.Json;

namespace Tweak.Examples
{
    public class ApiJson
    {
        public class Settings : SettingsBase<JsonSettingsReader>, IApiSettings
        {
            public string ApiKey { get; set; }
            public string Endpoint { get; set; }
        }
    }
}