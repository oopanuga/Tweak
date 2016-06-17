namespace Tweak.Tests.TestClasses
{
    public class ApiSettings : SettingsBase<CustomSettingReader, CustomSettingWriter>
    {
        public int ClientId { get; set; }
        public string ApiKey { get; set; }
    }
}