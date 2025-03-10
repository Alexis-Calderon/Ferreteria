namespace Ferreteria.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<(IEnumerable<T>, int)> GetAllAsync(string? filter, int page, int pageSize);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}