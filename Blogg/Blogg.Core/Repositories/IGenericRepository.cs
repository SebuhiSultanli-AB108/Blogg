namespace Blogg.Core.Repositories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetWhere(Func<T, bool> expression);
    Task<bool> IsExistAsync(int id);
    Task AddAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task DeleteAsync(T entity);
    Task<int> SaveAsync();
}
