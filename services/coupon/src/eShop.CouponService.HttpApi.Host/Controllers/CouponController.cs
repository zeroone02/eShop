using eShop.CouponService.Domain;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.CouponService.HttpApi.Host.Controllers;
[Route("api/coupon")]
[ApiController]
public class CouponController : ControllerBase
{
    private IRepository<Coupon, Guid> _repository;
    public CouponController(IRepository<Coupon, Guid> repository)
    {
        _repository = repository;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var obj  = await _repository.GetListAsync();
        return Ok(obj);
    }
}
