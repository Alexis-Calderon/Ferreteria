using Ferreteria.Application.Interfaces;
using Ferreteria.Application.Profiles;
using Ferreteria.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Ferreteria.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfileMapper).Assembly);
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}