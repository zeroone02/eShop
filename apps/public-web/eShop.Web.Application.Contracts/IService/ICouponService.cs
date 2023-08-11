using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;
namespace eShop.Web.Application.Contracts;
public interface ICouponService
{
    Task<ResponseDto?> GetCouponAsync(string couponCode);
    Task<ResponseDto?> GetAllCouponsAsync();
    Task<ResponseDto?> GetCouponByIdAsync(Guid id);
    Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto);
    Task<ResponseDto?> DeleteCouponAsync(Guid id);
    Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
}
