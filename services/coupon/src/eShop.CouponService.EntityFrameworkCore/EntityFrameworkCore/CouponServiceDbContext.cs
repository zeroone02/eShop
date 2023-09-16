using eShop.CouponService.Domain;
using eShop.DDD.Entity;
using Microsoft.EntityFrameworkCore;

namespace eShop.CouponService.EntityFrameworkCore;
public class CouponServiceDbContext : DbContext, IEfCoreDbContext
{
   public CouponServiceDbContext(DbContextOptions<CouponServiceDbContext> options )
        : base(options)
    {

    }
    public DbSet<Coupon> Coupons { get; set; }
    
    
}
