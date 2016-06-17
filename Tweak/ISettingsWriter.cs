using System.Collections.Generic;

namespace Tweak
{
    /// <summary>
    /// Represents the contract for a class that writes settings to a settings source.
    /// </summary>
    public interface ISettingsWriter
    {
        /// <summary>
        /// Writes settings to a settings source.
        /// </summary>
        /// <param name="settings">The settings.</param>
        void Write(IDictionary<string, string> settings);
    }
}