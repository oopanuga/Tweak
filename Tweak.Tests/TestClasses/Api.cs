namespace Tweak.Tests.TestClasses
{
    public class Api
    {
        public class Settings : SettingsBase<CustomSettingsReader, CustomSettingsWriter>
        {
            public Settings(bool autoReadSettings = true)
                : base(autoReadSettings)
            {
            }

            public int ClientId { get; set; }
            public string ApiKey { get; set; }
        }
    }
}