using eShop.ProductService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eShop.ProductService.Domain;
using AutoMapper;
using eShop.ProductService.EntityFrameworkCore;

namespace eShop.ProductService.HttpApi.Host.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService _ProductService;
    private UnitOfWork _unitOfWork;
    private ResponseDto _response;
    private ProductServiceDbContext _db;
    private IMapper _mapper;
    public ProductController(IProductService ProductService, UnitOfWork unitOfWork, ProductServiceDbContext db)
    {
        _ProductService = ProductService;
        _unitOfWork = unitOfWork;
        _response = new ResponseDto();
        _db = db;
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
    [Authorize(Roles = "ADMIN")]
    public  ResponseDto Create([FromForm] ProductDto productDto)
    {
        try
        {

            Product product = new();
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.CategoryName = productDto.CategoryName;
            product.ImageLocalPath = productDto.ImageLocalPath;
            product.ImageUrl = productDto.ImageUrl;

            _db.Products.Add(product);
            _db.SaveChanges();

            if (productDto.Image != null)
            {

                string fileName = product.Id + Path.GetExtension(productDto.Image.FileName);
                string filePath = @"wwwroot\ProductImages\" + fileName;

                //I have added the if condition to remove the any image with same name if that exist in the folder by any change
                var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                FileInfo file = new FileInfo(directoryLocation);
                if (file.Exists)
                {
                    file.Delete();
                }

                var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                {
                    productDto.Image.CopyTo(fileStream);
                }
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                product.ImageUrl = baseUrl + "/ProductImages/" + fileName;
                product.ImageLocalPath = filePath;
            }
            else
            {
                product.ImageUrl = "https://placehold.co/600x400";
            }
            _db.Products.Update(product);
            _db.SaveChanges();
            
          
            _response.Result = product;
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
    [Authorize(Roles = "ADMIN")]
    public async Task<ResponseDto> Delete(Guid id)
    {
        try
        {
            Product obj = _db.Products.First(u => u.Id == id);
            if (!string.IsNullOrEmpty(obj.ImageLocalPath))
            {
                var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.ImageLocalPath);
                FileInfo file = new FileInfo(oldFilePathDirectory);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            _db.Products.Remove(obj);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;

    }
    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<ResponseDto> Update([FromForm] ProductDto productDto)
    {
        try
        {
            Product product = new();
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.CategoryName = productDto.CategoryName;
            product.ImageLocalPath = productDto.ImageLocalPath;
            product.ImageUrl = productDto.ImageUrl;

            if (productDto.Image != null)
            {
                if (!string.IsNullOrEmpty(product.ImageLocalPath))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), product.ImageLocalPath);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }

                string fileName = product.Id + Path.GetExtension(productDto.Image.FileName);
                string filePath = @"wwwroot\ProductImages\" + fileName;
                var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                {
                    productDto.Image.CopyTo(fileStream);
                }
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                product.ImageUrl = baseUrl + "/ProductImages/" + fileName;
                product.ImageLocalPath = filePath;
            }


            _db.Products.Update(product);
            _db.SaveChanges();

            _response.Result = product;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

}
