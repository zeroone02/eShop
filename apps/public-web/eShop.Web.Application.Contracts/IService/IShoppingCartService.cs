using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;

namespace eShop.Web.Application.Contracts;
public interface IShoppingCartService
{
    Task<ResponseDto?> GetCartByUserIdAsync(string userId);
    Task<ResponseDto?> UpsertCartAsync(CartDto cartDto);
    Task<ResponseDto?> RemoveFromCartAsync(Guid cartDetailsId);
    Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto);
}
