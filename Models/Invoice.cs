using System;

public class Invoice
{
    public long Id { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Recurrence { get; set; }
    public string Recipient { get; set; }
    public string Description { get; set; }
    public int PassengerCount { get; set; }
    public DateTime Created { get; set; }
}