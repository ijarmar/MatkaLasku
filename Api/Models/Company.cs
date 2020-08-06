using System.Collections.Generic;

namespace MatkaLasku.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}