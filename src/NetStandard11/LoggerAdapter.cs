using Microsoft.Extensions.Logging;
using System;

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
            var logLevel = GetLogLevel(level);
            Logger.Log(logLevel, default(EventId), obj, null, null);
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, string str)
        {
            var logLevel = GetLogLevel(level);
            Logger.Log(logLevel, default(EventId), str, null, null);
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, string format, params object[] args)
        {
            var logLevel = GetLogLevel(level);
            Func<object[], Exception, string> formatter = (a, e) => string.Format(format, a);
            Logger.Log(logLevel, default(EventId), args, null, formatter);
        }

        /// <inheritdoc/>
        private Microsoft.Extensions.Logging.LogLevel GetLogLevel(LogLevel level)
        {
            return (Microsoft.Extensions.Logging.LogLevel)level;
        }
    }
}
