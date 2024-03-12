namespace Application;

public class Flight
{
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public string Airline { get; set; }
}