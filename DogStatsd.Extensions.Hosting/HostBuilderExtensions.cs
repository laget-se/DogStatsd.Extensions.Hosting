using Microsoft.Extensions.Hosting;

namespace StatsdClient.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseDogStatsd(this IHostBuilder builder, StatsdConfig config)
        {
            DogStatsd.Configure(config);

            return builder;
        }
    }
}
