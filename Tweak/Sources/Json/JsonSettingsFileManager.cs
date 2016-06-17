using System.Collections.Generic;
using System.Text;

namespace Tweak.Sources.Json
{
    /// <summary>
    /// Represents a class that manages adding and accessing json settings files.
    /// </summary>
    public static class JsonSettingsFileManager
    {
        public static List<SettingsFile> Files { get { return _fileStore.Files; } }

        private static readonly SettingsFileStore _fileStore;

        static JsonSettingsFileManager()
        {
            _fileStore = new SettingsFileStore();
        }

        /// <summary>
        /// Adds a settings file to the Files collection.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="encoding">The encoding to use when reading settings from the file.</param>
        /// <returns>The settings file store.</returns>
        public static SettingsFileStore AddFile(string fileName, Encoding encoding = null)
        {
            _fileStore.AddFile(fileName, encoding);

            return _fileStore;
        }
    }
}
