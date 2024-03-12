using Application;
using Infrastructure.Shared.MockFlight1;
using Infrastructure.Shared.MockFlight2;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Shared;

public static class ServiceCollection
{
    public static void AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFlightDataSource, MockFlightOneDataSource>();
        services.AddSingleton<IFlightDataSource, MockFlightTwoDataSource>();
    }
}