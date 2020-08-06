using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatkaLasku.Models
{
    public class Invoice
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long TripId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        
        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set; }

        public double KMAllowance { get; set; }
        public double DailyBenefit { get; set; }
        public double Total { get; set; } 
        public DateTime Created { get; set; } = DateTime.UtcNow; 
    }
}