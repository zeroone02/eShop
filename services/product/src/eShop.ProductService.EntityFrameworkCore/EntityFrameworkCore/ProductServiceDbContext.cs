using eShop.DDD.Entity;
using Microsoft.EntityFrameworkCore;
using eShop.ProductService.Domain;
namespace eShop.ProductService.EntityFrameworkCore;
public class ProductServiceDbContext : DbContext, IEfCoreDbContext
{
   public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options )
        : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
