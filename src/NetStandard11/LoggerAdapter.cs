using Microsoft.Extensions.Logging;

namespace Chimp.Logging.Extensions
{
    /// <summary>
    /// Microsoft.Extensions.Logging logger adapter.
    /// </summary>
    public sealed class LoggerAdapter : ILogger
    {
        private Microsoft.Extensions.Logging.ILogger Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerAdapter"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public LoggerAdapter(Microsoft.Extensions.Logging.ILogger logger)
        {
            Logger = logger;
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, object obj)
        {
            Logger.Log(GetLogLevel(level), default(EventId), obj, null, null);
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, string str)
        {
            Logger.Log(GetLogLevel(level), default(EventId), str, null, null);
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, string format, params object[] args)
        {
            string str = string.Format(format, args);
            Logger.Log(GetLogLevel(level), default(EventId), str, null, null);
        }

        /// <inheritdoc/>
        private Microsoft.Extensions.Logging.LogLevel GetLogLevel(LogLevel level)
        {
            return (Microsoft.Extensions.Logging.LogLevel)level;
        }
    }
}
