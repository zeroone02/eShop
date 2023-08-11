using static eShop.Web.Domain.Domain.Shared.SD;

namespace eShop.Web.Domain;
public class RequestDto
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object? Data { get; set; }
    public string AccessToken { get; set; }
}
