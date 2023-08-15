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
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Samosa",
            Price = 150,
            Description = "Each cabin has a large sail, so that the vehicles do not have room for visitors.<br/> Gas box coupons, biggest vikings. Upgrade your courses at a comfortable price.",
            ImageUrl = "https://placehold.co/603x403",
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Paneer Tikka",
            Price = 200,
            Description = "Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.",
            ImageUrl = "https://placehold.co/602x402",
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Sweet Pie",
            Price = 250,
            Description = "Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.",
            ImageUrl = "https://placehold.co/601x401",
            CategoryName = "Dessert"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Pav Bhaji",
            Price = 2500,
            Description = " Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.",
            ImageUrl = "https://placehold.co/600x400",
            CategoryName = "Entree"
        });
    }
}
