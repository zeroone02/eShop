namespace eShop.Web.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    IHttpClientFactory
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
