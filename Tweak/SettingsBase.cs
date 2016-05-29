using System;
using System.Collections.Generic;
using System.Linq;

namespace Tweak
{
    public class SettingsBase<TSettingsReader> : IReadSettings
        where TSettingsReader : ISettingsReader, new()
    {
        protected SettingsBase()
        {
            SetProperties(new TSettingsReader().Read());
        }

        private void SetProperties(IDictionary<string, string> settings)
        {
            var type = GetType();
            var properties = type.GetProperties();

            foreach (var propertyInfo in properties)
            {
                var setting = settings.SingleOrDefault(s =>
                {
                    if (s.Key.IndexOf('.') == -1) return s.Key == propertyInfo.Name;

                    var lastDotIndex = s.Key.LastIndexOf('.');
                    var className = s.Key.Substring(0, lastDotIndex);
                    var propertyName = s.Key.Substring(lastDotIndex + 1);

                    if (s.Key.Split('.').Length > 2)
                    {
                        return className == type.FullName
                                                   && propertyName == propertyInfo.Name;
                    }

                    return className == type.Name
                           && propertyName == propertyInfo.Name;
                });

                if (!setting.Equals(default(KeyValuePair<string, string>)))
                {
                    propertyInfo.SetValue(this,
                        Convert.ChangeType(setting.Value, propertyInfo.PropertyType));
                }
            }
        }
    }

    public class SettingsBase<TSettingsReader, TSettingsWriter> : SettingsBase<TSettingsReader>, IReadWriteSettings
        where TSettingsReader : ISettingsReader, new()
        where TSettingsWriter : ISettingsWriter, new()
    {
        protected SettingsBase() { }

        public void Write()
        {
            new TSettingsWriter().Writer(this);
        }
    }
}