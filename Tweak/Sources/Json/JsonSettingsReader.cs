using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Tweak.Sources.Json
{
    /// <summary>
    /// Represents a class that reads settings defined in a json file.
    /// </summary>
    /// <seealso cref="Tweak.ISettingsReader" />
    public class JsonSettingsReader : ISettingsReader
    {
        /// <summary>
        /// Reads settings defined in a json file.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> Read()
        {
            var settings = new Dictionary<string, string>();
            var jss = new JavaScriptSerializer();

            foreach (var file in JsonSettingsFileManager.Files)
            {
                var fileName =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileName);

                using (var fileReader = new StreamReader(fileName, file.Encoding))
                {
                    var json = fileReader.ReadToEnd();
                    var dictionary = jss.Deserialize<Dictionary<string, dynamic>>(json);

                    foreach (var kvp in dictionary)
                    {
                        if (!(kvp.Value is string) && kvp.Value is IEnumerable)
                        {
                            foreach (var vKvp in kvp.Value)
                            {
                                settings.Add(string.Format("{0}.{1}", kvp.Key, vKvp.Key), vKvp.Value);
                            }
                        }
                        else
                        {
                            settings.Add(kvp.Key, kvp.Value);
                        }
                    }
                }
            }

            return settings;
        }
    }
}