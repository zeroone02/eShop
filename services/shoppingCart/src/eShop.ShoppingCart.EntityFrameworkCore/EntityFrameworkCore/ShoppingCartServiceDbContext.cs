using eShop.DDD.Entity;
using Microsoft.EntityFrameworkCore;
namespace eShop.ShoppingCartService.EntityFrameworkCore;
public class ShoppingCartServiceDbContext : DbContext, IEfCoreDbContext
{
   public ShoppingCartServiceDbContext(DbContextOptions<ShoppingCartServiceDbContext> options )
        : base(options)
    {

    }
    //public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
