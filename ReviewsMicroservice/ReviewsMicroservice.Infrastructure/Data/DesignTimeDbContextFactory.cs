using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ReviewsMicroservice.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReviewsMicroserviceDbContext>
    {
        public ReviewsMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ReviewsMicroserviceDbContext>();
            // Adjust your connection string
            builder.UseSqlServer("Server=localhost,1433;Database=ReviewsMicroserviceDb;User Id=sa;Password=Sahil@1234;TrustServerCertificate=True;");
            return new ReviewsMicroserviceDbContext(builder.Options);
        }
    }
}
