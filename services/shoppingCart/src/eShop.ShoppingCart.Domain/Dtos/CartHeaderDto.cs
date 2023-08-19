using eShop.DDD.Application.Contracts;
namespace eShop.ShoppingCartService.Domain;
public class CartHeaderDto : EntityDto<Guid>
{
    public Guid? UserId { get; set; }
    public string? CouponCode { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
}
