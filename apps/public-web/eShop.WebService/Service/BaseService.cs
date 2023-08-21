using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain.Dtos.authDto;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static eShop.Web.Domain.Domain.Shared.SD;

namespace eShop.Web.Application;
public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenProvider _tokenProvider;
    public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
    {
        _httpClientFactory = httpClientFactory;
        _tokenProvider = tokenProvider;
    }
    public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient("eShop");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            if (withBearer)
            {
                var token = _tokenProvider.GetToken();
                message.Headers.Add("Authorization",$"Bearer {token}");
            }

            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? apiResponse = null;
            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            apiResponse = await client.SendAsync(message);
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Not Found"
                    };
                case HttpStatusCode.Forbidden:
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Access Denied"
                    };
                case HttpStatusCode.Unauthorized:
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Unauthorized"
                    };
                case HttpStatusCode.InternalServerError:
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Internal Server Error"
                    };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }
        }
        catch (Exception ex)
        {
            var dto = new ResponseDto()
            {
                IsSuccess = false,
                Message = ex.Message.ToString()
            };
            return dto;
        }
    }
}
