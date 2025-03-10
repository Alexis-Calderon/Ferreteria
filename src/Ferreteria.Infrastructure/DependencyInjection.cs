using Ferreteria.Domain.Interfaces;
using Ferreteria.Infrastructure.Context;
using Ferreteria.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ferreteria.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("FerreteriaDb")));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}