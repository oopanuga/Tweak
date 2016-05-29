using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Tweak.Sources.AppSettings
{
    public class AppSettingsReader : ISettingsReader
    {
        public IDictionary<string, string> Read()
        {
            return ToDictionary(ConfigurationManager.AppSettings);
        }

        private IDictionary<string, string> ToDictionary(NameValueCollection nameValueCollection)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var key in nameValueCollection.AllKeys)
            {
                dictionary.Add(key, nameValueCollection[key]);
            }
            return dictionary;
        }
    }
}