using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.WebUtility;
using System.Net.Http;

namespace eShop.Web.Application;
public class BaseService<T> : IBaseService<T>
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<ResponseDto<T>?> SendAsync(RequestDto<T> requestDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
    }
}
