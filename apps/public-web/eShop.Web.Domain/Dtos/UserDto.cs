using eShop.DDD.Application.Contracts;

namespace eShop.Web.Domain;
public class UserDto : EntityDto<string>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
