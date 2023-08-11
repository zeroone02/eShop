using eShop.AuthService.Domain;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eShop.AuthService.EntityFrameworkCore;
public class AuthServiceDbContext : IdentityDbContext<
    ApplicationUser>, IEfCoreDbContext
{
    public AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options)
         : base(options)
    {

    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
