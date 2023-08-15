using eShop.ProductService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductService.HttpApi.Host.Controllers;

[Route("api/product")]
[ApiController]
//[Authorize]
public class ProductController : ControllerBase
{
    private IProductService _ProductService;
    private UnitOfWork _unitOfWork;
    private ResponseDto _response;
    public ProductController(IProductService ProductService, UnitOfWork unitOfWork)
    {
        _ProductService = ProductService;
        _unitOfWork = unitOfWork;
        _response = new ResponseDto();
    }
    [HttpGet]
    public async Task<ResponseDto> GetList()
    {
        try
        {
            var result  = await _ProductService.GetListAsync();
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
            var result = await _ProductService.GetAsync(id);
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
    //[Authorize(Roles = "ADMIN")]
    public async Task<ResponseDto> Create([FromBody] ProductDto ProductDto)
    {
        try
        {
            var result = await _ProductService.AddAsync(ProductDto);
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
    [Route("deleteProduct/{id}")]
    //[Authorize(Roles = "ADMIN")]
    public async Task<ResponseDto> Delete(Guid id)
    {
        try
        {
            var result = await _ProductService.DeleteAsync(id);
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
    [HttpPut]
    //[Authorize(Roles = "ADMIN")]
    public async Task<ResponseDto> Update([FromBody] ProductDto ProductDto)
    {
        try
        {
            var result = await _ProductService.UpdateAsync(ProductDto);
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
