namespace Tweak
{
    public class SettingDescriptor
    {
        public SettingDescriptor(string settingName, string settingValue)
        {
            SettingName = settingName;
            SettingValue = settingValue;
        }

        public string SettingName { get; private set; }
        public string SettingValue { get; private set; }
    }
}
