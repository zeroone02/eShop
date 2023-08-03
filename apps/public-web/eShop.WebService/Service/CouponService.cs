using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;
using eShop.WebUtility;

namespace eShop.Web.Application;
public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;
    public CouponService(IBaseService baseService)
    {
        _baseService = baseService;
    }
    public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = couponDto,
            Url = SD.CouponApiBase + "/api/coupon" 
        });
    }

    public async Task<ResponseDto?> DeleteCouponAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.CouponApiBase + "/api/coupon/" + id
        });
    }

    public async Task<ResponseDto?> GetAllCouponsAsync()
    {
        return await _baseService.SendAsync(new RequestDto()
        { 
            ApiType = SD.ApiType.GET,
            Url = SD.CouponApiBase + "/api/coupon"
        });
    }

    public async Task<ResponseDto?> GetCouponAsync(string couponCode)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CouponApiBase + "/api/coupon/GetByCode/" + couponCode
        });
    }

    public async Task<ResponseDto?> GetCouponByIdAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CouponApiBase + "/api/coupon/GetById/" + id
        });
    }

    public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
    {

        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.PUT,
            Data = couponDto,
            Url = SD.CouponApiBase + "/api/coupon"
        });
    }
}
