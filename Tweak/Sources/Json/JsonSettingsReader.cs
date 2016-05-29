using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Tweak.Sources.Json
{
    public class JsonSettingsReader : ISettingsReader
    {
        public IDictionary<string, string> Read()
        {
            var settings = new Dictionary<string, string>();
            var jss = new JavaScriptSerializer();

            foreach (var file in JsonSettingsFileStore.Files)
            {
                var filePath =
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileName);

                using (var fileReader = new StreamReader(filePath, file.Encoding))
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