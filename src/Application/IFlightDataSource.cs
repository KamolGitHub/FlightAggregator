namespace Application;

public interface IFlightDataSource
{
    Task<List<Flight>> GetFlights(string from, string to, DateTime departureDate);
}