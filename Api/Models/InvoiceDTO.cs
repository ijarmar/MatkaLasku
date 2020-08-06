using System;

namespace MatkaLasku.Models
{
    public class InvoiceDTO
    {
        public long InvoiceNumber { get; set; }
        public string CompanyName { get; set; }
        public DateTime Departure { get; set; }
        public DateTime RecurrenceTime { get; set; }
        public string BenefitReciever { get; set; }
        public string Purpose { get; set; }
        public int DistanceInKM { get; set; }
        public string LocationDeparture { get; set; }
        public string LocationDestination { get; set; }
        public string Description { get; set; }
        public int PassengerCount { get; set; }
        public double KMAllowance { get; set; }
        public double DailyBenefit { get; set; }
        public double Total { get; set; } 
        public DateTime Created { get; set; }
    }
}