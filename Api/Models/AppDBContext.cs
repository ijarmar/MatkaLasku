using Microsoft.EntityFrameworkCore;

namespace MatkaLasku.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}