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
        if (coupons == null)
        {
            throw new Exception("Данные не найдены");
        }
        IEnumerable<CouponDto> couponDtos = _mapper.Map<IEnumerable<CouponDto>>(coupons);
        return couponDtos;
    }

    public async Task<CouponDto> GetByCodeAsync(string code)
    {
        
            Coupon coupon = _repository.GetQueryable().FirstOrDefault(x => x.CouponCode == code);

            if(coupon == null)
            {
                throw new Exception($"Запись с code = {code} не найдена");
            }

            CouponDto couponDto = _mapper.Map<CouponDto>(coupon);
            return couponDto;    
       
    }

    public async Task<CouponDto> GetAsync(Guid id)
    {
        Coupon coupon = await _repository.GetAsync(id);
        if (coupon == null)
        {
            throw new Exception($"Запись с id = {id} не найдена");
        }
        CouponDto couponDto = _mapper.Map<CouponDto>(coupon);
        return couponDto;
    }
}
