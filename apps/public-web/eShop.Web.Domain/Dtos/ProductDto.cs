using eShop.DDD.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace eShop.Web.Domain;

public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageLocalPath { get; set; }
    [Range(1,100)]
    public int Count { get; set; } = 1;
    [MaxFileSize(1)]
    [AllowedExtensions(new string[] { ".jpg", ".png" })]
    public IFormFile? Image { get; set; }

}

