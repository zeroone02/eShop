using eShop.DDD.Application.Contracts;
using eShop.WebUtility;

namespace eShop.Web.Application.Contracts;
public interface IBaseService<T>
{
    Task<ResponseDto<T>?> SendAsync(RequestDto<T> requestDto);
}
