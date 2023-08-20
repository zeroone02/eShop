using eShop.ShoppingCartService.Application.Contracts;
using eShop.ShoppingCartService.Domain;

namespace eShop.ShoppingCartService.Application;
public class ProductService : IProductService
{
    public Task<IEnumerable<ProductDto>> GetProducts()
    {
        throw new NotImplementedException();
    }
}
