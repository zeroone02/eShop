namespace eShop.DDD.Entity;
public class UnitOfWork
{
    private IEfCoreDbContext _db;

    public UnitOfWork(IEfCoreDbContext db)
    {
        db = _db;
    }
    public void SaveChangesAsync()
    {
        _db.SaveChangesAsync();
    }
}
