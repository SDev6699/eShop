using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderMicroservice.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrderMicroserviceDbContext>
    {
        public OrderMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrderMicroserviceDbContext>();
            // Example local connection string; adjust to your environment
            builder.UseSqlServer("Server=localhost,1433;Database=OrderMicroserviceDb;User Id=sa;Password=Sahil@1234;TrustServerCertificate=True;");

            return new OrderMicroserviceDbContext(builder.Options);
        }
    }
}