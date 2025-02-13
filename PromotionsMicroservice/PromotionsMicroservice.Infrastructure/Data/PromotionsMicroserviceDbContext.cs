using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Domain.Entities;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class PromotionsMicroserviceDbContext : DbContext
    {
        public PromotionsMicroserviceDbContext(DbContextOptions<PromotionsMicroserviceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetails> PromotionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: Promotion -> PromotionDetails
            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.PromotionDetails)
                .WithOne(d => d.Promotion)
                .HasForeignKey(d => d.PromotionId);
        }
    }
}