using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShop.Web.Controllers;
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    //
    [HttpGet]
    public IActionResult Login()
    {
        LoginRequestDto loginRequestDto = new();
        return View(loginRequestDto);
    }

    [HttpGet]
    public IActionResult Register()
    {
        var roleList = new List<SelectList>();
        return View();
    }
    [HttpGet]
    public IActionResult Logout()
    {
        return View();
    }
}
