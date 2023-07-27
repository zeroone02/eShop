using System.Data;
using eShop.CouponService.Domain;
using eShop.DDD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eShop.CouponService.EntityFrameworkCore;
public class CouponServiceDbContext : DbContext, IEfCoreDbContext
{
   public CouponServiceDbContext(DbContextOptions<CouponServiceDbContext> options )
        : base(options)
    {

    }
    DbSet<test> testdb { get; set; }
}
// dotnet ef migrations add test3