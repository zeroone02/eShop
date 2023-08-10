
using Microsoft.AspNetCore.Identity;

namespace eShop.AuthService.Domain;
public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }    
}
