using eShop.DDD.Application.Contracts;
using eShop.Web.Domain;

namespace eShop.Web.Application.Contracts;
public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}
