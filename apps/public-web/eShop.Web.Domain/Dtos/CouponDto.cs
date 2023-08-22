using eShop.DDD.Entity;

namespace eShop.Web.Domain;
public class CouponDto : Entity<Guid>
{
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}
