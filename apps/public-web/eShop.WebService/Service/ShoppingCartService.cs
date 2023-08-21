using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;

namespace eShop.Web.Application.Contracts;
public class ShoppingCartService : IShoppingCartservice
{
    public Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> GetCartByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> RemoveFromCartAsync(Guid cartDetailsId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
    {
        throw new NotImplementedException();
    }
}
