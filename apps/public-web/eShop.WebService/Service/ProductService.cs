﻿using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;

namespace eShop.Web.Application;
public class ProductService : IProductService
{
    private readonly IBaseService _baseService;
    public ProductService(IBaseService baseService)
    {
        _baseService = baseService;
    }
    public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.POST,
            Data = productDto,
            Url = SD.ProductApiBase + "/api/product"
        });
    }

    public async Task<ResponseDto?> DeleteProductAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductApiBase + "/api/product/deleteProduct/" + id
        });
    }

    public async Task<ResponseDto?> GetAllProductAsync()
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/product"
        });
    }

    public async Task<ResponseDto?> GetProductByIdAsync(Guid id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/product/GetById/" + id
        });
    }

    public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.PUT,
            Data = productDto,
            Url = SD.ProductApiBase + "/api/product"
        });
    }
}
