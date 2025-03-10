using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Ferreteria.Application.DTOs.Product;
using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;
using Ferreteria.Domain.Interfaces;
using Ferreteria.Domain.Models;

namespace Ferreteria.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponseDto> AddAsync(ProductCreateDto entity)
    {
        Product product = _mapper.Map<Product>(entity);
        await _productRepository.AddAsync(product);
        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task DeleteAsync(string code)
    {
        Product? product = await _productRepository.GetByCodeAsync(code) ?? throw new Exception("Product not found");
        product.IsDeleted = true;
        await _productRepository.UpdateAsync(product);
    }

    public async Task<GetAllResponse<ProductResponseDto>> GetAllAsync(string? filter, int page = 1, int pageSize = 10)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize != -1 && pageSize < 10 ? 10 : pageSize;

        (IEnumerable<Product> products, int totalCount) = await _productRepository.GetAllAsync(filter, page, pageSize);

        GetAllResponse<ProductResponseDto> response = new(
            totalCount,
            pageSize,
            page,
            _mapper.Map<List<ProductResponseDto>>(products)
        );

        return response;
    }

    public async Task<ProductResponseDto?> GetByIdAsync(string code)
    {
        Product? product = await _productRepository.GetByCodeAsync(code);
        return product is not null ? _mapper.Map<ProductResponseDto>(product) : null;
    }

    public async Task UpdateAsync(ProductUpdateDto entity)
    {
        Product product = await _productRepository.GetByCodeAsync(entity.Code) ?? throw new Exception("Product not found");
        _mapper.Map(entity, product);
        await _productRepository.UpdateAsync(product);
    }
}