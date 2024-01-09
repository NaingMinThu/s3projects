using NLog;
using ILogger = NLog.ILogger;

namespace PayLoadAPI.Logging
{
    public class LoggerService : ILoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Information the.
        /// </summary>
        /// <param name="message">The message.</param>MO
        public void Information(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Warnings the.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Debugs the.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Errors the.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
