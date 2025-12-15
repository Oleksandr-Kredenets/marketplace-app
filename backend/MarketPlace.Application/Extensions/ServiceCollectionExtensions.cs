using Microsoft.Extensions.DependencyInjection;
using MarketPlace.Persistance.Repositories;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Services;

namespace MarketPlace.Application.Extensions;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}