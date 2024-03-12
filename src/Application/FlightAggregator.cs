namespace Application;

public class FlightAggregator
{
    private readonly IEnumerable<IFlightDataSource> _dataSources;

    public FlightAggregator(IEnumerable<IFlightDataSource> dataSources)
    {
        _dataSources = dataSources ?? throw new ArgumentNullException(nameof(dataSources));
    }

    public async Task SearchFlightsAsync(string from, string to, DateTime departureDate, Func<List<Flight>, Task> callback)
    {
        var tasks = new List<Task<List<Flight>>>();

        // Executing all async method
        foreach (var dataSource in _dataSources)
        {
            tasks.Add(dataSource.GetFlights(from, to, departureDate));
        }

        // Waiting all of them
        while (tasks.Count > 0)
        {
            var completedTask = await Task.WhenAny(tasks);
            
            tasks.Remove(completedTask);

            var flights = await completedTask;
            
            // send the result to the client as each task is completed via delegate
            await callback(flights);
        }
    }
}