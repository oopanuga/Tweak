using System.Collections.Generic;
using System.Text;

namespace Tweak
{
    /// <summary>
    /// Represents a settings file store.
    /// </summary>
    public class SettingsFileStore
    {
        /// <summary>
        /// Gets the settings files.
        /// </summary>
        /// <value>
        /// The settings files.
        /// </value>
        public List<SettingsFile> Files { get; private set; }

        /// <summary>
        /// Adds a settings file to the Files collection.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="encoding">The encoding to use when reading settings from the file.</param>
        public virtual void AddFile(string fileName, Encoding encoding = null)
        {
            if (Files == null)
            {
                Files = new List<SettingsFile>();
            }

            Files.Add(
                new SettingsFile
                {
                    Encoding = encoding ?? Encoding.UTF8, 
                    FileName = fileName
                });
        }
    }
}