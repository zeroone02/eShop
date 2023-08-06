namespace eShop.AuthService.Application.Contracts;
public interface IAuthService
{
    Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
}
