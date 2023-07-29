using eShop.CouponService.Domain;

namespace eShop.CouponService.Application.Contracts;
public interface ICouponService
{
    public  Task<IEnumerable<CouponDto>> GetListAsync();
    public  Task<Coupon> GetAsync(Guid id);
    public  Task<CouponDto> GetByCodeAsync(string code);
}
