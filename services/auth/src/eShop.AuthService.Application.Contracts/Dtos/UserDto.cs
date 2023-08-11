using eShop.DDD.Application.Contracts;

namespace eShop.AuthService.Application.Contracts;
public class UserDto : EntityDto<string>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
