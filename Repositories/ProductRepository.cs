using LAB8CALIFICADO.Data;
using LAB8CALIFICADO.Models;
using LAB8CALIFICADO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB8CALIFICADO.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly LinqExampleContext _context;

    public ProductRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // Ejercicio 2: Obtener productos con precio mayor a un valor
    public async Task<List<Product>> GetProductsByPriceAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }

    // Ejercicio 5: Obtener el producto más caro
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    // Ejercicio 7: Obtener el promedio de precio de los productos
    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);
    }

    // Ejercicio 8: Obtener productos sin descripción
    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    // Ejercicio 11: Obtener productos vendidos a un cliente específico
    public async Task<List<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
}
