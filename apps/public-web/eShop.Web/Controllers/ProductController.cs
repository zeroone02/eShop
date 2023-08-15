using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eShop.Web.Controllers;
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> productIndex()
    {
        List<ProductDto>? list = new();
        ResponseDto? response = await _productService.GetAllProductAsync();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
        }
        else
        {
            TempData["error"] = response?.Message;
        }
        return View(list);
    }
    public async Task<IActionResult> productCreate()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> productCreate(ProductDto model)
    {
        if (ModelState.IsValid)
        {
            ResponseDto? response = await _productService.CreateProductsAsync(model);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "product created successfully";
                return RedirectToAction(nameof(productIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
        }
        return View(model);
    }

    public async Task<IActionResult> productDelete(Guid productId)
    {
        ResponseDto? response = await _productService.GetProductByIdAsync(productId);

        if (response != null && response.IsSuccess)
        {
            ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(model);
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> productDelete(ProductDto productDto)
    {
        ResponseDto? response = await _productService.DeleteProductAsync(productDto.Id);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "product deleted successfully";
            return RedirectToAction(nameof(productIndex));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(productDto);
    }
}