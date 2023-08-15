using eShop.DDD.Application.Contracts;
namespace eShop.Web.Domain;
public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
}

