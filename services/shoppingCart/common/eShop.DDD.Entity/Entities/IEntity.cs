namespace eShop.DDD.Entity;
public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
