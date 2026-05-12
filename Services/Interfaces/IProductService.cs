using LAB8CALIFICADO.DTOs;

namespace LAB8CALIFICADO.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetProductsByPriceAsync(decimal minPrice);
    Task<ProductDto?> GetMostExpensiveProductAsync();
    Task<AveragePriceDto> GetAveragePriceAsync();
    Task<List<ProductDto>> GetProductsWithoutDescriptionAsync();
    Task<List<string>> GetProductsByClientIdAsync(int clientId);
}
