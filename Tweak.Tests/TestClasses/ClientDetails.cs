namespace Tweak.Tests.TestClasses
{
    public class ClientDetails : SettingsBase<CustomSettingsReader, CustomSettingsWriter>
    {
        public int ClientId { get; set; }
        public string Website { get; set; }
    }
}