using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductMicroserviceDbContext : DbContext
    {
        public ProductMicroserviceDbContext(DbContextOptions<ProductMicroserviceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryVariation> CategoryVariations { get; set; }
        public DbSet<VariationValue> VariationValues { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<ProductVariationValue> ProductVariationValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: Category -> CategoryVariations
            modelBuilder.Entity<Category>()
                .HasMany(c => c.CategoryVariations)
                .WithOne(cv => cv.Category)
                .HasForeignKey(cv => cv.CategoryId);

            // Relationship: CategoryVariation -> VariationValues
            modelBuilder.Entity<CategoryVariation>()
                .HasMany(cv => cv.VariationValues)
                .WithOne(vv => vv.CategoryVariation)
                .HasForeignKey(vv => vv.CategoryVariationId);

            // Relationship: Product -> ProductVariationValues
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductVariationValues)
                .WithOne(pvv => pvv.Product)
                .HasForeignKey(pvv => pvv.ProductId);

            // Relationship: ProductVariationValue -> VariationValue
            // Change delete behavior to Restrict to avoid multiple cascade paths.
            modelBuilder.Entity<ProductVariationValue>()
                .HasOne(pvv => pvv.VariationValue)
                .WithMany()
                .HasForeignKey(pvv => pvv.VariationValueId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
