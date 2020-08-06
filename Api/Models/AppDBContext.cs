using Microsoft.EntityFrameworkCore;

namespace MatkaLasku.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Trips)
                .WithOne(t => t.Company)
                .IsRequired();

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Invoices)
                .WithOne(i => i.Trip)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Company)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}