using LAB8CALIFICADO.DTOs;
using LAB8CALIFICADO.Repositories.Interfaces;
using LAB8CALIFICADO.Services.Interfaces;

namespace LAB8CALIFICADO.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetProductsByPriceAsync(decimal minPrice)
    {
        var products = await _productRepository.GetProductsByPriceAsync(minPrice);
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }

    public async Task<ProductDto?> GetMostExpensiveProductAsync()
    {
        var product = await _productRepository.GetMostExpensiveProductAsync();
        if (product == null) return null;

        return new ProductDto
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task<AveragePriceDto> GetAveragePriceAsync()
    {
        var average = await _productRepository.GetAveragePriceAsync();
        return new AveragePriceDto { AveragePrice = average };
    }

    public async Task<List<ProductDto>> GetProductsWithoutDescriptionAsync()
    {
        var products = await _productRepository.GetProductsWithoutDescriptionAsync();
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }

    public async Task<List<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _productRepository.GetProductsByClientIdAsync(clientId);
    }
}
