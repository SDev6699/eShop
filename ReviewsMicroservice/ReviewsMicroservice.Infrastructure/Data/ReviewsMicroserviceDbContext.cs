using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.Domain.Entities;

namespace ReviewsMicroservice.Infrastructure.Data
{
    public class ReviewsMicroserviceDbContext : DbContext
    {
        public ReviewsMicroserviceDbContext(DbContextOptions<ReviewsMicroserviceDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerReview> CustomerReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations if needed
        }
    }
}