using eShop.DDD.Application.Contracts;
using eShop.Web.Domain.Dtos.authDto;

namespace eShop.Web.Application.Contracts;
public interface IAuthService
{
    Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
    Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);
    Task<ResponseDto> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);

}
