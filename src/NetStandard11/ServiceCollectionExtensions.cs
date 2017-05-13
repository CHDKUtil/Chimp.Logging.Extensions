using Microsoft.Extensions.DependencyInjection;

namespace Chimp.Logging.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Chimp.Logging adapter to the service collection.
        /// </summary>
        /// <param name="serviceCollection">Service collection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddChimpLogging(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ILoggerFactory, LoggerFactoryAdapter>();
        }
    }
}
