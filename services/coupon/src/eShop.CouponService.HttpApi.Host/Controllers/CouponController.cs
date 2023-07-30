using eShop.CouponService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eShop.CouponService.HttpApi.Host.Controllers;

[Route("api/coupon")]
[ApiController]
public class CouponController : ControllerBase
{
    private ICouponService _couponService;
    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var result  = await _couponService.GetListAsync();
            return Ok(ApiResponseBuilder.CreateApiResponse(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseBuilder.CreateErrorApiResponse<bool>(ex.Message));
        }
    }
    [HttpGet]
    [Route("GetByCode/{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        try
        {
            var result = await _couponService.GetByCodeAsync(code);
            return Ok(ApiResponseBuilder.CreateApiResponse(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseBuilder.CreateErrorApiResponse<CouponDto>(ex.Message));
        }
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var result = await _couponService.GetAsync(id);
            return Ok(ApiResponseBuilder.CreateApiResponse(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseBuilder.CreateErrorApiResponse<CouponDto>(ex.Message));
        }
    }

}
