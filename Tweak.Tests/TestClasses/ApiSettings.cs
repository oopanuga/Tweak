namespace Tweak.Tests.TestClasses
{
    public class ApiSettings : SettingsBase<CustomSettingsReader, CustomSettingsWriter>
    {
        public ApiSettings(bool autoReadSettings = true):base(autoReadSettings)
        {
        }

        public int ClientId { get; set; }
        public string ApiKey { get; set; }
    }
}