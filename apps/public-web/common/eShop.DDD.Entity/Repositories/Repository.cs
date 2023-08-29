using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace eShop.DDD.Entity;
public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityDto<TKey>
{
    private  readonly IEfCoreDbContext _dbContext;
    public Repository(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        _dbContext = ServiceProvider.GetService<IEfCoreDbContext>();
    }

    public IServiceProvider ServiceProvider { get; }

    public Task Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<TEntity> GetAsync(TKey id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);
        return entity;
    }

    public async Task<List<TEntity>> GetListAsync()
    {
        var list = await _dbContext.Set<TEntity>().ToListAsync();
        return list;
    }

    public IQueryable<TEntity> GetQueryable()
    {
        var dbSet = _dbContext.Set<TEntity>();
        return dbSet;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await _dbContext.Set<TEntity>().AddAsync(entity);
        return entry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _dbContext.Update(entity);
        return await Task.FromResult(entry.Entity);
    }

    public  IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] func)
    {
        var dbSet = _dbContext.Set<TEntity>();
        IQueryable<TEntity> queryable = dbSet;

        foreach (var item in func)
        {
            queryable = queryable.Include(item);
        }

        return queryable;
    }
}