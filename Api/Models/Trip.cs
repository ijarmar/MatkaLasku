using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatkaLasku.Models
{
    public class Trip
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public DateTime Departure { get; set; }
        public DateTime Recurrence { get; set; }
        public string Recipient { get; set; }
        public string Purpose { get; set; }
        public int DistanceInKM { get; set; }
        public string LocationDeparture { get; set; }
        public string LocationDestination { get; set; }
        public string Description { get; set; }
        public int PassengerCount { get; set; }
    }
}