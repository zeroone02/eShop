using AutoMapper;
using eShop.DDD.Entity;
using eShop.ProductService.Application.Contracts;
using eShop.ProductService.Domain;

namespace eShop.ProductService.Application;
public class ProductService : IProductService
{
    private readonly IRepository<Product, Guid> _repository;
    private IMapper _mapper;
    public ProductService(IRepository<Product, Guid> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> GetListAsync()
    {
        IEnumerable<Product> products = await _repository.GetListAsync();
        if (products == null)
        {
            throw new Exception("Данные не найдены");
        }
        IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        Product product = await _repository.GetAsync(id);
        if (product == null)
        {
            throw new Exception($"Запись с id = {id} не найдена");
        }
        ProductDto productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
    public async Task<Product> AddAsync(ProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _repository.InsertAsync(product);
        return product;
    }

    public async Task<Product> DeleteAsync(Guid id)
    {
        var product = await _repository.GetAsync(id);
        await _repository.Delete(product);
        return product;
    }

    public async Task<ProductDto> UpdateAsync(ProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _repository.UpdateAsync(product);
        productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
}
