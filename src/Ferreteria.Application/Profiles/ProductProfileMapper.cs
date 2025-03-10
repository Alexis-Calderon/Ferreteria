using AutoMapper;

using Ferreteria.Application.DTOs.Product;
using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Profiles;

public class ProductProfileMapper : Profile
{
    public ProductProfileMapper()
    {
        CreateMap<Product, ProductResponseDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}