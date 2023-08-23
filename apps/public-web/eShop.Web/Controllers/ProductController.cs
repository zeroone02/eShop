using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace eShop.Web.Controllers;
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
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
    //toDo
    ///Добавить imageUrl во view
    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }
    [HttpPost]
    //Доделать
    public async Task<IActionResult> ProductCreate(ProductDto model)
    {
        //toDo
        // свойства product из productService должны совпадать с product в eshop.Web 
        model.Id = Guid.NewGuid();
        model.ImageUrl = "https://placehold.co/600x400";
        
        //if (ModelState.IsValid)
        //{
            ResponseDto? response = await _productService.CreateProductsAsync(model);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "product created successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
        //}
        return View(model);
    }
    ///Добавить imageUrl во view
    public async Task<IActionResult> ProductDelete(Guid productId)
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
    public async Task<IActionResult> ProductDelete(ProductDto productDto)
    {
        ResponseDto? response = await _productService.DeleteProductAsync(productDto.Id);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "product deleted successfully";
            return RedirectToAction(nameof(ProductIndex));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(productDto);
    }
    ///Добавить imageUrl во view
    public async Task<IActionResult> ProductEdit(Guid productId)
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
    public async Task<IActionResult> ProductEdit(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            ResponseDto? response = await _productService.UpdateProductAsync(productDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product updated successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
        }
        return View(productDto);
    }
}