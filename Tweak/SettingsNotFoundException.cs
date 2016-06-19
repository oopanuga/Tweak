using System;

namespace Tweak
{
    /// <summary>
    /// Represents an exception thats thrown when settings have not been defined
    /// in the settings source.
    /// </summary>
    public class SettingsNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SettingsNotFoundException class.
        /// </summary>
        public SettingsNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of SettingsNotFoundException with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error</param>
        public SettingsNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of SettingsNotFoundException with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">A message that describes the error</param>
        /// <param name="innerException">The cause of the current exception</param>
        public SettingsNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
