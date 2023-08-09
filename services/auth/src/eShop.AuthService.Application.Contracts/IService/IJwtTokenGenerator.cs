using eShop.AuthService.Domain;

namespace eShop.AuthService.Application.Contracts;
public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser);
}
