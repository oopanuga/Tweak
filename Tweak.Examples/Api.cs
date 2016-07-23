using Tweak.Sources.AppSettings;

namespace Tweak.Examples
{
    public class Api
    {
        public class Settings : SettingsBase<AppSettingsReader>, IApiSettings
        {
            public string ApiKey { get; set; }
            public string Endpoint { get; set; }
        }
    }
}