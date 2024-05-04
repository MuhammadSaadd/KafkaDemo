using Microsoft.EntityFrameworkCore;

namespace Kafka.Api;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
