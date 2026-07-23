using MarketPlace.Application.Dto;
using MarketPlace.Application.Query.Sorting;
namespace MarketPlace.Application.Interfaces;

public interface IProductService
{
    public string GenerateSlug(Guid id, string title);
    public Task<List<ProductResponse>> GetAllProductsAsync(ProductSortArgs args);
    public Task<ProductResponse?> GetProductBySlugAsync(string slug);
    public Task<ProductResponse?> AddProductAsync(ProductRequest product);
    public Task<ProductResponse?> UpdateProductAsync(ProductDataRequest product);
    public Task<ProductResponse?> DeleteProductAsync(Guid id);
}