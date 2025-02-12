using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductMicroservice.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductMicroserviceDbContext>
    {
        public ProductMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProductMicroserviceDbContext>();
            builder.UseSqlServer("Server=localhost,1433;Database=ProductMicroserviceDb;User Id=sa;Password=Sahil@1234;TrustServerCertificate=True;");

            return new ProductMicroserviceDbContext(builder.Options);
        }
    }
}