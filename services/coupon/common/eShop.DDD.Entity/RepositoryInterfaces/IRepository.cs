using System.Linq.Expressions;


namespace eShop.DDD.Entity;
public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    Task<TEntity> InsertAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    IQueryable<TEntity> GetQueryable();
    Task<TEntity> GetAsync(TKey id);
    Task<List<TEntity>> GetListAsync();
    Task<TEntity> UpdateAsync(TEntity entity);
    IQueryable<TEntity> WithDetailsAsync(params Expression<Func<TEntity, object>>[] func);
}
