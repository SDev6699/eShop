using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShippingMicroserviceDbContext>
    {
        public ShippingMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShippingMicroserviceDbContext>();
            builder.UseSqlServer("Server=localhost,1433;Database=ShippingMicroserviceDb;User Id=sa;Password=Sahil@1234;TrustServerCertificate=True;");
            return new ShippingMicroserviceDbContext(builder.Options);
        }
    }
}