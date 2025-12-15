using MarketPlace.Domain.Models;
namespace MarketPlace.Application.Interfaces;

public interface IProductService
{
    public string GenerateSlug(Product product);
    public Task<List<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductBySlugAsync(string slug);
    public Task<Product?> AddProductAsync(Product product);
    public Task<Product?> UpdateProductAsync(Product product);
    public Task<Product?> DeleteProductAsync(Guid id);
}