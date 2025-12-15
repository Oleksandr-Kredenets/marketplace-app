using Cyrillic.Convert;
using MarketPlace.Domain.Models;
using MarketPlace.Application.Interfaces;
using MarketPlace.Domain.Interfaces;
namespace MarketPlace.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository){
        _productRepository = productRepository;
    }

    public string GenerateSlug(Product product)
    {
        var conversion = new Conversion();
        string slug = conversion.UkrainianCyrillicToLatin(
                      conversion.RussianCyrillicToLatin(product.Title.ToLower()))
                      .Replace(" ", "-") + $"-{product.Id}";
        return slug;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllProductsAsync();
    }

    public async Task<Product?> GetProductBySlugAsync(string slug){
        return await _productRepository.GetProductBySlugAsync(slug);
    }

    public async Task<Product?> AddProductAsync(Product product)
    {
        return await _productRepository.AddProductAsync(product);
    }

    public async Task<Product?> UpdateProductAsync(Product updatedProduct)
    {
        Product? product = 
            await _productRepository.GetProductByIdAsync(updatedProduct.Id);

        if (product != null)
        {
            product.Title = updatedProduct.Title;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            await _productRepository.UpdateProductAsync(product);
            return product;
        }
        return null;
    }

    public async Task<Product?> DeleteProductAsync(Guid id)
    {
        Product? product = 
            await _productRepository.GetProductByIdAsync(id);
        
        if (product != null)
        {
            await _productRepository.RemoveProductAsync(product);
            return product;
        }
        return null;
    }
}