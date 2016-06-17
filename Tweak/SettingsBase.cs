using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tweak
{
    /// <summary>
    /// Represents the contract for settings class only reads settings from a settings source.
    /// </summary>
    /// <typeparam name="TSettingsReader">The type of the settings reader.</typeparam>
    public class SettingsBase<TSettingsReader>
        where TSettingsReader : ISettingsReader, new()
    {
        public IDictionary<string, string> Settings { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsBase{TSettingsReader}"/> class.
        /// </summary>
        /// <param name="autoReadSettings">if set to <c>true</c> [automatically read settings].</param>
        protected SettingsBase(bool autoReadSettings = true)
        {
            if (autoReadSettings)
            {
                Read();
            }
        }

        /// <summary>
        /// Reads settings from a settings source using the settings reader
        /// and then sets the class properties with these.
        /// </summary>
        public void Read()
        {
            Settings = new TSettingsReader().Read();
            var type = GetType();

            foreach (var propertyInfo in type.GetProperties())
            {
                var setting = FindMatchingSetting(propertyInfo, type);

                if (!setting.Equals(default(KeyValuePair<string, string>)))
                {
                    propertyInfo.SetValue(this,
                        Convert.ChangeType(setting.Value, propertyInfo.PropertyType));
                }
            }
        }

        /// <summary>
        /// Finds a setting that has a key that matches the property name.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="type">The type.</param>
        /// <returns>The setting.</returns>
        protected KeyValuePair<string, string> FindMatchingSetting(PropertyInfo propertyInfo, Type type)
        {
            var setting = Settings.LastOrDefault(s =>
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

            return setting;
        }
    }

    /// <summary>
    /// Represents the contract for settings class that reads and writes settings.
    /// </summary>
    /// <typeparam name="TSettingsReader">The type of the settings reader.</typeparam>
    /// <typeparam name="TSettingsWriter">The type of the settings writer.</typeparam>
    public class SettingsBase<TSettingsReader, TSettingsWriter> : SettingsBase<TSettingsReader>
        where TSettingsReader : ISettingsReader, new()
        where TSettingsWriter : ISettingsWriter, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsBase{TSettingsReader, TSettingsWriter}"/> class.
        /// </summary>
        /// <param name="autoReadSettings">if set to <c>true</c> [automatically read settings].</param>
        protected SettingsBase(bool autoReadSettings = true) 
            : base(autoReadSettings) { }

        /// <summary>
        /// Writes settings to a settings source using the settings writer.
        /// </summary>
        public void Write()
        {
            if (Settings == null)
            {
                Read();
            }

            var updatedSettings = new Dictionary<string, string>();
            var type = GetType();

            foreach (var propertyInfo in type.GetProperties())
            {
                var setting = FindMatchingSetting(propertyInfo, type);

                if (!setting.Equals(default(KeyValuePair<string, string>)))
                {
                    updatedSettings.Add(setting.Key, propertyInfo.GetValue(this).ToString());
                }
            }

            new TSettingsWriter().Write(updatedSettings);
        }
    }
}