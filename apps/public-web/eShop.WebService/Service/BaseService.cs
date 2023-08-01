using eShop.DDD.Application.Contracts;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain.Domain.Shared;
using eShop.WebUtility;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using static eShop.Web.Domain.Domain.Shared.SD;

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
        try
        {



            HttpClient client = _httpClientFactory.CreateClient("eShop");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? apiResponse = null;
            switch (requestDto.ApiType)
            {
                case ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
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
                        Error = new ErrorResult()
                        {
                            Message = "Not Found",
                            Details = ""

                        }
                    };
                case HttpStatusCode.Forbidden:
                    return new()
                    {
                        IsSuccess = false,
                        Error = new ErrorResult()
                        {
                            Message = "Access Denied",
                            Details = ""

                        }
                    };
                case HttpStatusCode.Unauthorized:
                    return new()
                    {
                        IsSuccess = false,
                        Error = new ErrorResult()
                        {
                            Message = "Unauthorized",
                            Details = ""

                        }
                    };
                case HttpStatusCode.InternalServerError:
                    return new()
                    {
                        IsSuccess = false,
                        Error = new ErrorResult()
                        {
                            Message = "Internal Server Error",
                            Details = ""

                        }
                    };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto<T>>(apiContent);
                    return apiResponseDto;
            }
        }
        catch (Exception ex)
        {
            var dto = new ResponseDto<T>()
            {
                IsSuccess = false,
                Error = new ErrorResult()
                {
                    Message = ex.Message,
                    Details = "Ошибка"

                }
            };
            return dto;
        }
    }
}
