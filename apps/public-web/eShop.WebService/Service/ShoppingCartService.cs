using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;

namespace eShop.Web.Application.Contracts;
public class ShoppingCartService : IShoppingCartService
{
    private readonly IBaseService _baseService;
    public ShoppingCartService(IBaseService baseService)
    {
        _baseService = baseService;
    }
    public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartApiBase + "/api/cart/ApplyCoupon"
        });
    }

    public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ShoppingCartApiBase + "/api/cart/GetCart/" + userId
        });
    }

    public async Task<ResponseDto?> RemoveFromCartAsync(Guid cartDetailsId)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDetailsId,
            Url = SD.ShoppingCartApiBase + "/api/cart/RemoveCart"
        });
    }

    public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartApiBase + "/api/cart/CartUpsert"
        });
    }
}
