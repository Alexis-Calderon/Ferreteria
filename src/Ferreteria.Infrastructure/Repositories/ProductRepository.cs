using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ferreteria.Domain.Entities;
using Ferreteria.Domain.Interfaces;
using Ferreteria.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext applicationDbContext) : IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task AddAsync(Product entity)
    {
        await _applicationDbContext.Products.AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        _applicationDbContext.Products.Remove(entity);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Product>, int)> GetAllAsync(string? filter, int page, int pageSize)
    {
        IQueryable<Product> queryable = _applicationDbContext.Products
            .AsNoTracking()
            .Where(p => string.IsNullOrEmpty(filter) ||
                p.Name.Contains(filter) ||
                p.Code.Contains(filter) ||
                (!string.IsNullOrEmpty(p.Description) && p.Description.Contains(filter)) ||
                (!string.IsNullOrEmpty(p.CategoryName) && p.CategoryName.Contains(filter)) ||
                (!string.IsNullOrEmpty(p.Brand) && p.Brand.Contains(filter)) ||
                (!string.IsNullOrEmpty(p.SupplierRut) && p.SupplierRut.Contains(filter)))
            .OrderBy(p => p.Name);

        int totalCount = await queryable.CountAsync();

        pageSize = pageSize == -1 ? totalCount : pageSize;

        List<Product> items = await queryable
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        return (items, totalCount);
    }

    public Task<Product?> GetByCodeAsync(string code)
    {
        return _applicationDbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Code == code);
    }

    public Task UpdateAsync(Product entity)
    {
        _applicationDbContext.Products.Update(entity);
        return _applicationDbContext.SaveChangesAsync();
    }
}