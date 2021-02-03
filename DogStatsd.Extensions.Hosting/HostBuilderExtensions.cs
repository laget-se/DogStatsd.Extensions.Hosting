using System;
using Microsoft.Extensions.Hosting;

namespace StatsdClient.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseDogStatsd(this IHostBuilder builder, StatsdConfig config)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            ConfigureDogStatsd(config);

            return builder;
        }

        public static IHostBuilder UseDogStatsd(this IHostBuilder builder, Func<HostBuilderContext, StatsdConfig> options)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices((context, services) =>
            {
                var config = options(context);
                ConfigureDogStatsd(config);
            });

            return builder;
        }

        private static void ConfigureDogStatsd(StatsdConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            DogStatsd.Configure(config);
        }
    }
}
