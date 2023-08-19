using eShop.DDD.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ShoppingCartService.Domain;
public class CartDetails : Entity<Guid>
{
    public Guid CartHeaderId { get; set; }
    [ForeignKey("CartHeaderId")]
    public CartHeader CartHeader { get; set; }
    public Guid ProductId { get; set; }
    [NotMapped]
    public ProductDto Product { get; set; }
}
