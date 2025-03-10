using Ferreteria.Domain.Entities;

namespace Ferreteria.Domain.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetByCodeAsync(string code);
}