using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PromotionsMicroserviceDbContext>
    {
        public PromotionsMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PromotionsMicroserviceDbContext>();
            // Example local connection string; adjust as needed
            builder.UseSqlServer("Server=localhost,1433;Database=PromotionsMicroserviceDb;User Id=sa;Password=Sahil@1234;TrustServerCertificate=True;");
            return new PromotionsMicroserviceDbContext(builder.Options);
        }
    }
}