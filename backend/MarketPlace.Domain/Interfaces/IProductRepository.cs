using MarketPlace.Domain.Models;
using MarketPlace.Domain.Collections;
namespace MarketPlace.Domain.Interfaces;

public interface IProductRepository
{
    public Task<List<Product>> GetAllProductsAsync(ProductQuery query);
    public Task<Product?> GetProductByIdAsync(Guid id);
    public Task<Product?> GetProductBySlugAsync(string slug);
    public Task<Product?> AddProductAsync(Product product);
    public Task<Product?> UpdateProductAsync(Product product);
    public Task<Product?> RemoveProductAsync(Product product);
}
