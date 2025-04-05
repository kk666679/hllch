using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique Index for Vendor UserId
            modelBuilder.Entity<Vendor>()
                .HasIndex(v => v.UserId)
                .IsUnique();

            // Relationship: Vendor -> Products
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products)
                .HasForeignKey(p => p.VendorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Soft Delete Filtering
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Vendor>().HasQueryFilter(v => !v.IsDeleted);

            // Index for Faster Queries
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.VendorId, p.Name });
        }
    }
}
