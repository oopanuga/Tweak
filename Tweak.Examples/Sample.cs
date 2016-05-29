using Tweak.Sources.AppSettings;

namespace Tweak.Examples
{
    public interface IWebSettings
    {
        string Name { get; set; }
        string Url { get; set; }
    }

    public class WebSettings : SettingsBase<AppSettingsReader>, IWebSettings
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
    }
}
