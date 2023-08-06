
using eShop.AuthService.Application.Contracts;
using eShop.AuthService.Domain;
using eShop.AuthService.EntityFrameworkCore;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Identity;

namespace eShop.AuthService.Application;
public class AuthService : IAuthService
{
    private readonly AuthServiceDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthService(AuthServiceDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
    }


    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
    {
        throw new NotImplementedException();
    }
}
