using System;

namespace MatkaLasku.Models
{
    public class TripDTO
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Recurrence { get; set; }
        public string Recipient { get; set; }
        public string Description { get; set; }
        public int PassengerCount { get; set; }
    }
}