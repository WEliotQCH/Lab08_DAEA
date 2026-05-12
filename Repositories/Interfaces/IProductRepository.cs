using LAB8CALIFICADO.Models;

namespace LAB8CALIFICADO.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsByPriceAsync(decimal minPrice);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();
    Task<List<string>> GetProductsByClientIdAsync(int clientId);
}
