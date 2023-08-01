using static eShop.Web.Domain.Domain.Shared.SD;

namespace eShop.WebUtility;
public class RequestDto<T>
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public T Data { get; set; }
    public string AccessToken { get; set; }
}
