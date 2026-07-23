using MarketPlace.Domain.Interfaces;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Services;
using MarketPlace.Infrastructure.Storages;
using MarketPlace.Infrastructure.Repositories;

namespace MarketPlace.Web.Extensions;
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