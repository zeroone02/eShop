using eShop.DDD.Entity;

namespace eShop.Web.Domain;
public class CouponDto : EntityDto<Guid>
{
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}
