namespace PayLoadAPI.Logging
{
    /// <summary>
    /// The logger service.
    /// </summary>

    public interface ILoggerService
    {

        /// <summary>
        /// Information the.
        /// </summary>
        /// <param name="message">The message.</param>
        void Information(string message);
        /// <summary>
        /// Warnings the.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(string message);
        /// <summary>
        /// Debugs the.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);
        /// <summary>
        /// Errors the.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);
    }
}
