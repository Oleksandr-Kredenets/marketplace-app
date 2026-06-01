using Cyrillic.Convert;
using MarketPlace.Domain.Models;
using MarketPlace.Domain.Interfaces;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Dto;
using MarketPlace.Infrastructure.Interfaces;
namespace MarketPlace.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IImageStorage _imageStorage;

    public ProductService(IProductRepository productRepository, IImageStorage imageStorage){
        _productRepository = productRepository;
        _imageStorage = imageStorage;
    }

    public string GenerateSlug(Guid id, string title)
    {
        var conversion = new Conversion();
        string slug = conversion.UkrainianCyrillicToLatin(
                      conversion.RussianCyrillicToLatin(title.ToLower()))
                      .Replace(" ", "-") + $"-{id}";
        return slug;
    }

    public async Task<List<ProductResponse>> GetAllProductsAsync()
    {
        List<Product> productsData = await _productRepository.GetAllProductsAsync();
        var products = new List<ProductResponse>();
        foreach (var productData in productsData)
        {
            string imageUrl = await _imageStorage.GetImageUrlAsync(productData.ImageObjectName).ConfigureAwait(false);
            var product = new ProductResponse(productData.Id, productData.UserId, productData.Title,
                                              productData.Price, productData.Description, productData.Slug, imageUrl);
            products.Add(product);
        }
        return products;
    }

    public async Task<ProductResponse?> GetProductBySlugAsync(string slug){
        Product? productData = await _productRepository.GetProductBySlugAsync(slug);
        if (productData != null)
        {
            string imageUrl = await _imageStorage.GetImageUrlAsync(productData.ImageObjectName);
            var product = new ProductResponse(productData.Id, productData.UserId, productData.Title,
                                              productData.Price, productData.Description, productData.Slug, imageUrl);
            return product;
        }
        return null;
    }
    public async Task<ProductResponse?> AddProductAsync(ProductRequest product)
    {
        Product ?productModel = new Product(product.UserId, product.Title, product.Price,
                                           product.Description);
        productModel.Slug = GenerateSlug(productModel.Id, productModel.Title);
        productModel.ImageObjectName = $"{productModel.Title}_{productModel.Id}";

        _imageStorage.UploadImageSync(productModel.ImageObjectName, product.Image);
        productModel = await _productRepository.AddProductAsync(productModel);

        if (productModel == null)
            return null;
        string imageUrl = await _imageStorage.GetImageUrlAsync(productModel.ImageObjectName).ConfigureAwait(false);
        return new ProductResponse(productModel.Id, productModel.UserId, productModel.Title, productModel.Price,
                                   productModel.Description, productModel.Slug, imageUrl);
    }
    public async Task<ProductResponse?> UpdateProductAsync(ProductDataRequest updatedProduct)
    {
        Product? product = 
            await _productRepository.GetProductByIdAsync(updatedProduct.Id);

        if (product == null)
            return null;

        product.Title = updatedProduct.Title;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
        await _productRepository.UpdateProductAsync(product);
        string imageUrl = await _imageStorage.GetImageUrlAsync(product.ImageObjectName).ConfigureAwait(false);
        return new ProductResponse(product.Id, product.UserId, product.Title, product.Price,
                                    product.Description, product.Slug, imageUrl);
    }
    public async Task<ProductResponse?> DeleteProductAsync(Guid id)
    {
        Product? product = 
            await _productRepository.GetProductByIdAsync(id);

        if (product == null)
            return null;
        await _productRepository.RemoveProductAsync(product);
        _imageStorage.DeleteImageSync(product.ImageObjectName);
        
        return new ProductResponse(product.Id, product.UserId, product.Title, product.Price,
                                   product.Description, product.Slug, "");
    }
}