using Settingly.Readers;

namespace Settingly
{
    public class SettingsBase<TSettingsReader, TSettingsWriter> : SettingsBase<TSettingsReader>, IReadWriteSettings
        where TSettingsReader : ISettingsReader, new()
        where TSettingsWriter : ISettingsWriter, new()
    {
        protected SettingsBase() { }

        public void Write()
        {
            new TSettingsWriter().Writer(this);
        }
    }
}