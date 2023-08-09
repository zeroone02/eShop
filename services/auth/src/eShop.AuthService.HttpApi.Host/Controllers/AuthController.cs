﻿using eShop.AuthService.Application.Contracts;
using eShop.DDD.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eShop.AuthService.HttpApi.Host;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    protected ResponseDto _response;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
        _response = new();
    }

    [HttpPost("AssignRole")]
    public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
    {
        var assignRoleSuccessful = await _authService.AssignRole(model.Email,model.Role.ToUpper());
        if (!assignRoleSuccessful)
        {
            _response.IsSuccess = false;
            _response.Message = "Error encountered";
            return BadRequest(_response);
        }
        return Ok(_response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
    {
        var errorMessage = await _authService.Register(model);
        if(!string.IsNullOrEmpty(errorMessage))
        {
            _response.IsSuccess = false;
            _response.Message = errorMessage;
            return BadRequest(_response);
        }
        return Ok(_response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var loginResponse = await _authService.Login(model);
        if(loginResponse.User == null )
        {
            _response.IsSuccess = false;
            _response.Message = "Username or password incorrect";
            return BadRequest(_response);
        }
        _response.Result = loginResponse;
        return Ok(_response);
    }
}
