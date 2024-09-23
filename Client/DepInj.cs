using Client.Interfaces;
using Client.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DepInj
    {
        public static void RegisterServiceBusClient(
            this IServiceCollection services,
            Action<ServiceBusClientOptions> configureServiceBusClientOptions)
        {
            services.ConfigureServiceOptions<ServiceBusClientOptions>((_, options) => configureServiceBusClientOptions(options));
            services.AddTransient<IServiceBusClient, ServiceBusClient>();
        }
        
        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
    }
}