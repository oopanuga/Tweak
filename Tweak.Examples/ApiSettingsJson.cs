using Tweak.Sources.Json;

namespace Tweak.Examples
{
    public class ApiSettingsJson : SettingsBase<JsonSettingsReader>, IApiSettings
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
    }
}