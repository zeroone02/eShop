using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;
namespace eShop.Web.Application.Contracts;
public interface IProductService
{
    Task<ResponseDto?> GetAllProductAsync();
    Task<ResponseDto?> GetProductByIdAsync(Guid id);
    Task<ResponseDto?> CreateProductsAsync(ProductDto productDto);
    Task<ResponseDto?> DeleteProductAsync(Guid id);
    Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
}
