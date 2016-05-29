namespace Tweak
{
    public interface ISettingsWriter
    {
        void Writer<T>(T settings) where T : IReadWriteSettings;
    }
}