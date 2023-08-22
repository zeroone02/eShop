using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;
using eShop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace eShop.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    IShoppingCartService _shoppingCartService;
    public HomeController(ILogger<HomeController> logger, IProductService productService, IShoppingCartService shoppingCartService)
    {
        _logger = logger;
        _productService = productService;
        _shoppingCartService = shoppingCartService;
    }

    public async Task<IActionResult> Index()
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
    [Authorize]
    public async Task<IActionResult> ProductDetails(Guid id)
    {
        ProductDto? model = new();

        ResponseDto? response = await _productService.GetProductByIdAsync(id);

        if (response != null && response.IsSuccess)
        {
            model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(model);
    }

    [Authorize(Roles = SD.RoleAdmin)]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
