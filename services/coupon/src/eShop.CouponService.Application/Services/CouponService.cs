using AutoMapper;
using eShop.CouponService.Application.Contracts;
using eShop.CouponService.Domain;
using eShop.DDD.Entity;

namespace eShop.CouponService.Application;
public class CouponService : ICouponService
{
    private readonly IRepository<Coupon,Guid> _repository;
    private IMapper _mapper;
    public CouponService(IRepository<Coupon, Guid> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CouponDto>> GetListAsync()
    {
        IEnumerable<Coupon> coupons = await _repository.GetListAsync();
        IEnumerable<CouponDto> couponDtos = _mapper.Map<IEnumerable<CouponDto>>(coupons);
        return couponDtos;
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
