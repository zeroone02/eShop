using eShop.Web.Application;
using eShop.Web.Application.Contracts;
using eShop.Web.Domain.Domain.Shared;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddHttpClient<ICouponService,CouponService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();

SD.ShoppingCartApiBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
SD.CouponApiBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.AuthApiBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.ProductApiBase = builder.Configuration["ServiceUrls:ProductAPI"];

builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
