using AutoMapper;
using eShop.ProductService.Domain;

namespace eShop.ProductService.Application.Contracts;
public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
			config.CreateMap<ProductDto, Product>().ReverseMap();
		});
        return mappingConfig;
    }
}
