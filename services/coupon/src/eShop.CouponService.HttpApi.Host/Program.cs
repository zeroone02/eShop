using eShop.CouponService.Application;
using eShop.CouponService.Application.Contracts;
using eShop.CouponService.Domain;
using eShop.CouponService.EntityFrameworkCore;
using eShop.DDD.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Register DbContext
builder.Services.AddDbContext<IEfCoreDbContext, CouponServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IRepository<Coupon, Guid>, Repository<Coupon, Guid>>();
builder.Services.AddTransient<ICouponService, CouponService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<CouponServiceDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0 )
        {
            _db.Database.Migrate();
        }
    }
}
