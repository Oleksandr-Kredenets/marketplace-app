using Microsoft.AspNetCore.Mvc;
using MarketPlace.Domain.Models;
using MarketPlace.API.Contracts;
using MarketPlace.Application.Interfaces;

namespace MarketPlace.API.Controllers;

[ApiController]
[Route("/products")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(Json(products));
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetProduct(string slug){
        Product? product = await _productService.GetProductBySlugAsync(slug);
        if (product == null) return NotFound("Product not found");
        return Ok(Json(product));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(PostProductDto productRequest)
    {
        Product newProduct = new Product(productRequest.UserId, productRequest.Title,
                                         productRequest.Price, productRequest.Description);

        newProduct.Slug = _productService.GenerateSlug(newProduct);

        if (await _productService.AddProductAsync(newProduct) != null)
        {
            return RedirectToAction("GetAllProducts");
        }
        else
        {
            return BadRequest(RedirectToAction("GetAllProducts"));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody]PutProductDto productRequest)
    {
        Product updatedProduct = new Product(Guid.Empty,
                                             productRequest.Title,
                                             productRequest.Price,
                                             productRequest.Description);
        updatedProduct.Id = productRequest.Id;
        await _productService.UpdateProductAsync(updatedProduct);
        return RedirectToAction("GetAllProducts");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery]Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("GetAllProducts");
    }
}