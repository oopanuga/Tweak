using System.Collections.Generic;

namespace Tweak.Tests.TestClasses
{
    public class CustomSettingWriter : ISettingsWriter
    {
        public static IDictionary<string, string> Settings { get; private set; }
        public void Write(IDictionary<string, string> settings)
        {
            Settings = settings;
        }
    }
}
