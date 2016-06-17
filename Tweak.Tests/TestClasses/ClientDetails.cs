namespace Tweak.Tests.TestClasses
{
    public class ClientDetails : SettingsBase<CustomSettingReader, CustomSettingWriter>
    {
        public int ClientId { get; set; }
        public string Website { get; set; }
    }
}