using Microsoft.Extensions.DependencyInjection;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Services;
using MarketPlace.Infrastructure.Repositories;
using MarketPlace.Infrastructure.Storages;
using MarketPlace.Infrastructure.Interfaces;

namespace MarketPlace.Application.Extensions;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IImageStorage, MinioImageStorage>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}