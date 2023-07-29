using eShop.DDD.Entity;
using System.ComponentModel.DataAnnotations;

namespace eShop.CouponService.Domain;
public class Coupon : Entity<Guid> 
{
    public string CouponCode { get; set; }
    public decimal DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}
