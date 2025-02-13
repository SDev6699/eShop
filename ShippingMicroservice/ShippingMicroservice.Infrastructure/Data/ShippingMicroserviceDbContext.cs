using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.Domain.Entities;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShippingMicroserviceDbContext : DbContext
    {
        public ShippingMicroserviceDbContext(DbContextOptions<ShippingMicroserviceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShipperRegion> ShipperRegions { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShipperRegion>()
                .HasOne(sr => sr.Region)
                .WithMany(r => r.ShipperRegions)
                .HasForeignKey(sr => sr.RegionId);

            modelBuilder.Entity<ShipperRegion>()
                .HasOne(sr => sr.Shipper)
                .WithMany(s => s.ShipperRegions)
                .HasForeignKey(sr => sr.ShipperId);

            modelBuilder.Entity<ShippingDetails>()
                .HasOne(sd => sd.Shipper)
                .WithMany()
                .HasForeignKey(sd => sd.ShipperId);
        }
    }
}