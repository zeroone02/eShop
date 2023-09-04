using System.ComponentModel.DataAnnotations;

namespace eShop.Web.Domain;
public class LoginRequestDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
