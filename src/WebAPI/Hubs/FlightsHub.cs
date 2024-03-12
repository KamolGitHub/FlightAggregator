using System.Text.Json.Serialization;
using Application;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class FlightsHub : Hub
{
    private readonly FlightAggregator _flightAggregator;

    public FlightsHub(FlightAggregator flightAggregator)
    {
        _flightAggregator = flightAggregator ?? throw new ArgumentNullException(nameof(flightAggregator));
    }

    public async Task Search(string from, string to, DateTime departureDate)
    {
        await _flightAggregator.SearchFlightsAsync(from, to, departureDate, async flights =>
        {
            await Clients.Caller.SendAsync("ReceiveFlights", flights);
        });
    }
}