using Application;

namespace Infrastructure.Shared.MockFlight1;

public class MockFlightOneDataSource : IFlightDataSource
{
    public async Task<List<Flight>> GetFlights(string from, string to, DateTime departureDate)
    {
        //await some method from data source
        
        //set timeout for httpClient in order to avoid long responses

        await Task.Delay(3000);
        
        return new List<Flight>
        {
            new Flight
            {
                From = from,
                To = to,
                DepartureTime = departureDate.AddHours(8),
                ArrivalTime = departureDate.AddHours(10),
                Price = 750,
                Airline = "Some Airline 1"
            },
            // here we can add another mock data
        };
    }
}