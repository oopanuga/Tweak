using System.Collections.Generic;
using System.Text;

namespace Tweak
{
    public class FileStore
    {
        public List<File> Files { get; private set; }

        public void AddFile(string fileName, Encoding encoding = null)
        {
            if (Files == null)
            {
                Files = new List<File>();
            }

            Files.Add(
                new File
                {
                    Encoding = encoding ?? Encoding.UTF8, 
                    FileName = fileName
                });
        }
    }

    public class File
    {
        public string FileName { get; set; }
        public Encoding Encoding { get; set; }
    }
}