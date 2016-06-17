using System.Collections.Generic;

namespace Tweak
{
    /// <summary>
    /// Represents the contract for a class that reads settings from a settings source.
    /// </summary>
    public interface ISettingsReader
    {
        /// <summary>
        /// Reads settings from a settings source.
        /// </summary>
        /// <returns>The settings</returns>
        IDictionary<string, string> Read();
    }
}