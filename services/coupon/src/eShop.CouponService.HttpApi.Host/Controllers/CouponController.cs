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
    private ResponseDto _response;
    public CouponController(ICouponService couponService, UnitOfWork unitOfWork)
    {
        _couponService = couponService;
        _unitOfWork = unitOfWork;
        _response = new ResponseDto();
    }
    [HttpGet]
    public async Task<ResponseDto> GetList()
    {
        try
        {
            var result  = await _couponService.GetListAsync();
            _response.Result = result;
            
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }
    [HttpGet]
    [Route("GetByCode/{code}")]
    public async Task<ResponseDto> GetByCode(string code)
    {
        try
        {
            var result = await _couponService.GetByCodeAsync(code);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ResponseDto> GetById(Guid id)
    {
        try
        {
            var result = await _couponService.GetAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpPost]
    public async Task<ResponseDto> CreateCoupon([FromBody] CouponDto couponDto)
    {
        try
        {
            var result = await _couponService.AddAsync(couponDto);
            await _unitOfWork.SaveChangesAsync();
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpDelete]
    public async Task<ResponseDto> DeleteCoupon(Guid id)
    {
        try
        {
            var result = await _couponService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

}
