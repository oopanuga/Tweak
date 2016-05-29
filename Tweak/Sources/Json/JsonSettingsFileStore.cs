using System.Collections.Generic;
using System.Text;

namespace Tweak.Sources.Json
{
    public static class JsonSettingsFileStore
    {
        public static List<File> Files { get { return _fileStore.Files; } }

        private static readonly FileStore _fileStore;

        static JsonSettingsFileStore()
        {
            _fileStore = new FileStore();
        }

        public static FileStore AddFile(string fileName, Encoding encoding = null)
        {
            _fileStore.AddFile(fileName, encoding);

            return _fileStore;
        }
    }
}
