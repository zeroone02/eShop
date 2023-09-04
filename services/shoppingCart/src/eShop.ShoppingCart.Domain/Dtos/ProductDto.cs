using eShop.DDD.Application.Contracts;
using System.ComponentModel.DataAnnotations;

namespace eShop.ShoppingCartService.Domain;
 public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}
