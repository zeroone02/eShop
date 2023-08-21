using eShop.DDD.Application.Contracts;
namespace eShop.Web.Domain;
public class CartDetailsDto : EntityDto<Guid>
{
    public Guid CartHeaderId { get; set; }
    public CartHeaderDto? CartHeader { get; set; }
    public Guid ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int Count { get; set; }
}
