using Hllch.Core.Models;  // Changed from ECommerce.Core
using Microsoft.EntityFrameworkCore;

namespace Hllch.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add your model configurations here
        }
    }
}
