using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShop.DDD.Entity;
public class UnitOfWork
{
    private readonly IEfCoreDbContext _dbContext;
    public IServiceProvider ServiceProvider { get; }
    public UnitOfWork(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        _dbContext = ServiceProvider.GetService<IEfCoreDbContext>();
    }

    public async  Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
