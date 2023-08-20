
using eShop.ShoppingCartService.Domain;

namespace eShop.ShoppingCartService.Application.Contracts;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
}
