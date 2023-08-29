namespace eShop.DDD.Entity;
public abstract class EntityDto<T> : IEntity<T>
{
    public EntityDto() { }
    public EntityDto(T id)
    {
        Id = id;
    }

    public virtual T Id { get; set; }
}