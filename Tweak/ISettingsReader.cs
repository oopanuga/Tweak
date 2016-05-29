using System.Collections.Generic;

namespace Tweak
{
    public interface ISettingsReader
    {
        IDictionary<string, string> Read();
    }
}