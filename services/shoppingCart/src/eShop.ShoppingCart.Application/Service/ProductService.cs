using eShop.DDD.Application.Contracts;
using eShop.ShoppingCartService.Application.Contracts;
using eShop.ShoppingCartService.Domain;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace eShop.ShoppingCartService.Application;
public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var client = _httpClientFactory.CreateClient("Product");
        var response = await client.GetAsync($"/api/product");
        var apiContent = await response.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
        if (resp.IsSuccess ) 
        {
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
        }
        return new List<ProductDto>();
    }
}
