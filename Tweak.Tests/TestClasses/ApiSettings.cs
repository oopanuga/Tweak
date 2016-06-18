namespace Tweak.Tests.TestClasses
{
    public class ApiSettings : SettingsBase<CustomSettingsReader, CustomSettingsWriter>
    {
        public int ClientId { get; set; }
        public string ApiKey { get; set; }
    }
}