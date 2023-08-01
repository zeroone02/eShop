using eShop.CouponService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Mvc;

namespace eShop.CouponService.HttpApi.Host.Controllers;

[Route("api/coupon")]
[ApiController]
public class CouponController : ControllerBase
{
    private ICouponService _couponService;
    private UnitOfWork _unitOfWork;
    public CouponController(ICouponService couponService, UnitOfWork unitOfWork)
    {
        _couponService = couponService;
        _unitOfWork = unitOfWork;
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

    [HttpPost]
    public async Task<IActionResult> CreateCoupon([FromBody] CouponDto couponDto)
    {
        try
        {
            var result = await _couponService.AddAsync(couponDto);
            await _unitOfWork.SaveChangesAsync();
            return Ok(ApiResponseBuilder.CreateApiResponse(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseBuilder.CreateErrorApiResponse<CouponDto>(ex.Message,"Купон не создан"));
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(Guid id)
    {
        try
        {
            var result = await _couponService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok(ApiResponseBuilder.CreateApiResponse(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponseBuilder.CreateErrorApiResponse<CouponDto>(ex.Message));
        }
    }

}
