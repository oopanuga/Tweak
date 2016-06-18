using System.Collections.Generic;

namespace Tweak.Tests.TestClasses
{
    public class CustomSettingsReader : ISettingsReader
    {
        public static Dictionary<string, string> Settings { get; set; }
        public IDictionary<string, string> Read()
        {
            return Settings;
        }
    }
}