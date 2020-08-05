using System.Collections.Generic;

public class Company
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Trip> Trips { get; set; }
}