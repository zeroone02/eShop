﻿using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;

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
            Url = SD.CouponAPIBase + "/api/coupon" 
        });
    }

    public async Task<ResponseDto?> DeleteCouponAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.CouponAPIBase + "/api/coupon/deleteCoupon/" + id
        });
    }

    public async Task<ResponseDto?> GetAllCouponsAsync()
    {
        return await _baseService.SendAsync(new RequestDto()
        { 
            ApiType = SD.ApiType.GET,
            Url = SD.CouponAPIBase + "/api/coupon"
        });
    }

    public async Task<ResponseDto?> GetCouponAsync(string couponCode)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
        });
    }

    public async Task<ResponseDto?> GetCouponByIdAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CouponAPIBase + "/api/coupon/GetById/" + id
        });
    }

    public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
    {

        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.PUT,
            Data = couponDto,
            Url = SD.CouponAPIBase + "/api/coupon"
        });
    }
}
