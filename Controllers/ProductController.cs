using LAB8CALIFICADO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB8CALIFICADO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Ejercicio 2: Obtener productos con precio mayor a un valor específico
    /// </summary>
    [HttpGet("by-price/{minPrice}")]
    public async Task<IActionResult> GetProductsByPrice(decimal minPrice)
    {
        var products = await _productService.GetProductsByPriceAsync(minPrice);
        return Ok(products);
    }

    /// <summary>
    /// Ejercicio 5: Obtener el producto más caro
    /// </summary>
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _productService.GetMostExpensiveProductAsync();
        return Ok(product);
    }

    /// <summary>
    /// Ejercicio 7: Obtener el promedio de precio de los productos
    /// </summary>
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _productService.GetAveragePriceAsync();
        return Ok(average);
    }

    /// <summary>
    /// Ejercicio 8: Obtener productos sin descripción
    /// </summary>
    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }

    /// <summary>
    /// Ejercicio 11: Obtener productos vendidos a un cliente específico
    /// </summary>
    [HttpGet("by-client/{clientId}")]
    public async Task<IActionResult> GetProductsByClientId(int clientId)
    {
        var products = await _productService.GetProductsByClientIdAsync(clientId);
        return Ok(products);
    }
}
