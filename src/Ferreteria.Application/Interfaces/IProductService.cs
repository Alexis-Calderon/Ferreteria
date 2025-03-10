using System.Threading.Tasks;

using Ferreteria.Application.DTOs.Product;
using Ferreteria.Domain.Models;

namespace Ferreteria.Application.Interfaces;

public interface IProductService
{
    Task<GetAllResponse<ProductResponseDto>> GetAllAsync(string? filter, int page = 1, int pageSize = 10);
    Task<ProductResponseDto?> GetByIdAsync(string code);
    Task<ProductResponseDto> AddAsync(ProductCreateDto entity);
    Task UpdateAsync(ProductUpdateDto entity);
    Task DeleteAsync(string code);
}