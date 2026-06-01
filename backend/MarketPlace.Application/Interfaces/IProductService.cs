using MarketPlace.Domain.Models;
using MarketPlace.Application.Dto;

namespace MarketPlace.Application.Interfaces;

public interface IProductService
{
    public string GenerateSlug(Guid id, string title);
    public Task<List<ProductResponse>> GetAllProductsAsync();
    public Task<ProductResponse?> GetProductBySlugAsync(string slug);
    public Task<ProductResponse?> AddProductAsync(ProductRequest product);
    public Task<ProductResponse?> UpdateProductAsync(ProductDataRequest product);
    public Task<ProductResponse?> DeleteProductAsync(Guid id);
}