using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain;
using eShop.Web.Domain.Domain.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eShop.Web.Controllers;
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly ITokenProvider _tokenProvider;

    public AuthController(IAuthService authService, ITokenProvider tokenProvider)
    {
        _authService = authService;
        _tokenProvider = tokenProvider;
    }
    //
    [HttpGet]
    public IActionResult Login()
    {
        LoginRequestDto loginRequestDto = new();
        return View(loginRequestDto);
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto obj)
    {
        ResponseDto responseDto = await _authService.LoginAsync(obj);
        if (responseDto != null && responseDto.IsSuccess)
        {
            LoginResponseDto loginResponseDto = 
                JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
            _tokenProvider.SetToken(loginResponseDto.Token);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("CustomError",responseDto.Message);
            return View(obj);
        }
       
    }

    [HttpGet]
    public IActionResult Register()
    {
        var roleList = new List<SelectListItem>()
        {
            new SelectListItem() {Text=SD.RoleAdmin,Value=SD.RoleAdmin},
            new SelectListItem() {Text=SD.RoleCustomer,Value=SD.RoleCustomer},
        };
        ViewBag.RoleList = roleList;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegistrationRequestDto obj)
    {
        ResponseDto result = await _authService.RegisterAsync(obj);
        ResponseDto assignRole;
        if (result != null && result.IsSuccess)
        {
            if (string.IsNullOrEmpty( obj.Role))
            {
                obj.Role = SD.RoleCustomer;
            }
            assignRole = await _authService.AssignRoleAsync(obj);
            if (assignRole != null && assignRole.IsSuccess)
            {
                TempData["success"] = "Registration Successful";
                return RedirectToAction(nameof(Login));
            }
        }
        var roleList = new List<SelectListItem>()
        {
            new SelectListItem() {Text=SD.RoleAdmin,Value=SD.RoleAdmin},
            new SelectListItem() {Text=SD.RoleCustomer,Value=SD.RoleCustomer},
        };
        ViewBag.RoleList = roleList;
        return View(obj);
    }
    [HttpGet]
    public IActionResult Logout()
    {
        return View();
    }
    public async Task SignInUser(LoginRequestDto model)
    {
        var handler = new JwtSecurityTokenHandler
        var principal = ClaimsPrincipal()
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
