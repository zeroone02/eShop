using eShop.ProductService.Application.Contracts;
using eShop.ProductService.Domain;

namespace eShop.ProductService.Application;
public class ProductService : IProductService
{
    public Task<Product> AddAsync(ProductDto ProductDto)
    {
        throw new NotImplementedException();
    }

    public Task<Product> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> UpdateAsync(ProductDto ProductDto)
    {
        throw new NotImplementedException();
    }
}
