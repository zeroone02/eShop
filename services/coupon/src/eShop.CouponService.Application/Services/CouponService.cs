using eShop.CouponService.Application.Contracts;
using eShop.CouponService.Domain;
using eShop.DDD.Entity;

namespace eShop.CouponService.Application;
public class CouponService : ICouponService
{
    private readonly IRepository<Coupon,Guid> _repository;
    public CouponService(IRepository<Coupon, Guid> repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<CouponDto>> GetListAsync()
    {
        //var couponDtos = await _repository.GetListAsync();
        throw new NotImplementedException();

    }

    public async Task<CouponDto> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public async Task<Coupon> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
