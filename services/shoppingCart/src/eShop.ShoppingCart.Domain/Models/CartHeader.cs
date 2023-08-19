using eShop.DDD.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ShoppingCartService.Domain;
public class CartHeader : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? CouponCode { get; set; }

    [NotMapped]
    public double Discount { get; set; }
    [NotMapped]
    public double CartTotal { get; set; }
}
