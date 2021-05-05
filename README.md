# DogStatsd.Extensions.Hosting
Hosting and startup abstractions for DogStatsd. When using NuGet 3.x this package requires at least version 3.4....

## Usage
> To see the full documentation for StatsdConfig please refer to the [documentation](https://github.com/DataDog/dogstatsd-csharp-client/blob/master/src/StatsdClient/StatsdConfig.cs)

```c#
await Host.CreateDefaultBuilder()
    .UseDogStatsd(new StatsdConfig
    {
        StatsdServerName = "127.0.0.1",
        Prefix = "prefix",
    })
    .Build()
    .RunAsync();
```

```c#
await Host.CreateDefaultBuilder()
    .UseDogStatsd((context) => new StatsdConfig
    {
        StatsdServerName = context.HostingEnvironment.IsProduction() ? "127.0.0.1" : "127.0.0.2",
        Prefix = "prefix"
    })
    .Build()
    .RunAsync();
```
