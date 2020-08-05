using System;

public class Trip
{
    public long Id { get; set; }
    public Company Company { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Recurrence { get; set; }
    public string Recipient { get; set; }
    public string Description { get; set; }
    public int PassengerCount { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}