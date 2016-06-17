using Tweak.Sources.AppSettings;

namespace Tweak.Examples
{
    public class ApiSettings : SettingsBase<AppSettingsReader>, IApiSettings
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
    }
}