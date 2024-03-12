using Application;

namespace Infrastructure.Shared.MockFlight2;

public class MockFlightTwoDataSource : IFlightDataSource
{
    public async Task<List<Flight>> GetFlights(string from, string to, DateTime departureDate)
    {
        //await some method from data source
        
        // set timeout httpClient in order to avoid long responses
        
        await Task.Delay(1000);
        
        return new List<Flight>
        {
            new Flight
            {
                From = from,
                To = to,
                DepartureTime = departureDate.AddHours(10),
                ArrivalTime = departureDate.AddHours(12),
                Price = 250,
                Airline = "Some Airline 2"
            },
        };
    }
}