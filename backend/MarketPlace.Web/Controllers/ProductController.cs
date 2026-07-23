using Microsoft.AspNetCore.Mvc;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Dto;
using MarketPlace.Application.Query.Sorting;
using MarketPlace.Infrastructure.Collections;
using MarketPlace.Web.Contracts;

namespace MarketPlace.Web.Controllers;

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
    public async Task<IActionResult> GetAllProducts([FromQuery]SortProductContract args)
    {
        var argsRequest = new ProductSortArgs
        {
            SortBy = args.SortBy,
            Dimension = args.Dimension
        };

        var products = await _productService.GetAllProductsAsync(argsRequest);
        return Ok(Json(products));
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetProduct(string slug){
        var product = await _productService.GetProductBySlugAsync(slug);
        if (product == null) return NotFound("Product not found");
        return Ok(Json(product));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm]PostProductContract product)
    {
        var imageStream = product.Image.OpenReadStream();
        if (!FileTypes.Types.Contains(product.Image.ContentType))
        {
            return StatusCode(StatusCodes.Status415UnsupportedMediaType);
        }
        if (imageStream == null || imageStream.Length == 0)
        {
            return BadRequest(RedirectToAction("GetAllProducts"));
        }
        ProductRequest productRequest = new ProductRequest(product.UserId, product.Title, product.Price,
                                                           imageStream, product.Description);
    
        var result = await _productService.AddProductAsync(productRequest);
        imageStream.Close();
        
        if (result != null)
        {
            return RedirectToAction("GetAllProducts");
        }
        else
        {
            return BadRequest(RedirectToAction("GetAllProducts"));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody]PutProductContract productRequest)
    {
        var updatedProduct = new ProductDataRequest(productRequest.Id,
                                                    productRequest.Title,
                                                    productRequest.Price,
                                                    productRequest.Description);
        await _productService.UpdateProductAsync(updatedProduct);
        return RedirectToAction("GetAllProducts");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("GetAllProducts");
    }
}