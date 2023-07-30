﻿using eShop.CouponService.Domain;

namespace eShop.CouponService.Application.Contracts;
public interface ICouponService
{
    public  Task<IEnumerable<CouponDto>> GetListAsync();
    public  Task<CouponDto> GetAsync(Guid id);
    public  Task<CouponDto> GetByCodeAsync(string code);
}
