namespace Application;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddSingleton<FlightAggregator>();
    }
}