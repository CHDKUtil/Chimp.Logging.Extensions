using System;
using Microsoft.Extensions.Logging;

namespace Chimp.Logging.Extensions
{
    /// <summary>
    /// Microsoft.Extensions.Logging logger factory adapter.
    /// </summary>
    public sealed class LoggerFactoryAdapter : ILoggerFactory
    {
        private Microsoft.Extensions.Logging.ILoggerFactory LoggerFactory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerFactoryAdapter"/> class.
        /// </summary>
        /// <param name="loggerFactory">Logger factory.</param>
        public LoggerFactoryAdapter(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }

        /// <inheritdoc/>
        public ILogger CreateLogger(string name)
        {
            var logger = LoggerFactory.CreateLogger(name);
            return new LoggerAdapter(logger);
        }

        /// <inheritdoc/>
        public ILogger CreateLogger(Type type)
        {
            var logger = LoggerFactory.CreateLogger(type);
            return new LoggerAdapter(logger);
        }

        /// <inheritdoc/>
        public ILogger CreateLogger<T>()
        {
            var logger = LoggerFactory.CreateLogger<T>();
            return new LoggerAdapter(logger);
        }
    }
}
