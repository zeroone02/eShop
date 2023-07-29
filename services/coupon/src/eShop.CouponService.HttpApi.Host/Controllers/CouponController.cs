using eShop.CouponService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eShop.CouponService.HttpApi.Host.Controllers;
[Route("api/coupon")]
[ApiController]
public class CouponController : ControllerBase
{
    private ResponseDto _responseDto;
    private ICouponService _couponService;
    public CouponController(ICouponService couponService)
    {
        _responseDto = new ResponseDto();
        _couponService = couponService;
    }
    [HttpGet]
    public async Task<ResponseDto> GetList()
    {
        try
        {
            _responseDto.Result =  await _couponService.GetListAsync();
        }
        catch (Exception ex)
        {
            _responseDto.IsSuccess = false;
            _responseDto.Message = ex.Message;
        }
        return _responseDto;
    }

}
