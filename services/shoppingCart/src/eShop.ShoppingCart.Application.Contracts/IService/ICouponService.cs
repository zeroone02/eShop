
using eShop.ShoppingCartService.Domain;

namespace eShop.ShoppingCartService.Application.Contracts;
public interface ICouponService
{
    Task<CouponDto> GetCoupon(string couponCode);
}
