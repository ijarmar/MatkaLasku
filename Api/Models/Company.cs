using System.Collections.Generic;

namespace MatkaLasku.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}