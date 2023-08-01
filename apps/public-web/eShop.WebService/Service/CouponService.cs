using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;

namespace eShop.Web.Application;
public class CouponService : ICouponService
{
    public Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> DeleteCouponAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> GetAllCouponsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> GetCouponAsync(string couponCode)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> GetCouponByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }
}
