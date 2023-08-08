﻿
using eShop.AuthService.Application.Contracts;
using eShop.AuthService.Domain;
using eShop.AuthService.EntityFrameworkCore;
using eShop.DDD.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
    {
        ApplicationUser user = new()
        {
            UserName = registrationRequestDto.Email,
            Email = registrationRequestDto.Email,
            NormalizedEmail = registrationRequestDto.Email.ToUpper(),
            Name = registrationRequestDto.Name,
            PhoneNumber = registrationRequestDto.PhoneNumber
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
            if (result.Succeeded)
            {
                var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                UserDto userDto = new()
                {
                    Email = userToReturn.Email,
                    Id = userToReturn.Id,
                    Name = userToReturn.Name,
                    PhoneNumber = userToReturn.PhoneNumber
                };

                return "";

            }
            else
            {
                return result.Errors.FirstOrDefault().Description;
            }

        }
        catch (Exception ex)
        {

        }
        return "Error Encountered";
    }
}
