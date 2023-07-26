using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace eShop.DDD.Entity;
public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    private  readonly IEfCoreDbContext _dbContext;
    public Repository(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        _dbContext = ServiceProvider.GetService<IEfCoreDbContext>();
    }

    public IServiceProvider ServiceProvider { get; }

    public Task DeleteAsync(TEntity entity)
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
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _dbContext.Update(entity);
        return Task.FromResult(entry.Entity);
    }

    public IQueryable<TEntity> WithDetailsAsync(params Expression<Func<TEntity, object>>[] func)
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