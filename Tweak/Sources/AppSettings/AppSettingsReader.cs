using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Tweak.Sources.AppSettings
{
    /// <summary>
    /// Represents a class that reads settings defined in the appSettings section of an app or web config file.
    /// </summary>
    /// <seealso cref="Tweak.ISettingsReader" />
    public class AppSettingsReader : ISettingsReader
    {
        /// <summary>
        /// Reads settings defined in the appSettings section of an app or web config file.
        /// </summary>
        /// <returns>The settings.</returns>
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