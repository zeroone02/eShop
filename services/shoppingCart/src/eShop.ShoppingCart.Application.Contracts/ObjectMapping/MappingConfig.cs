using AutoMapper;
using eShop.ShoppingCartService.Domain;

namespace eShop.ShoppingCartService.Application.Contracts;
public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
        });
        return mappingConfig;
    }
}
