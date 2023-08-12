namespace eShop.Web.Application.Contracts;
public interface ITokenProvider
{
    void SetToken(string token);
    string? GetToken();
    void ClearToken();
}
