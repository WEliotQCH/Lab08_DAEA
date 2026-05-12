using LAB8CALIFICADO.Data;
using LAB8CALIFICADO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB8CALIFICADO.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly LinqExampleContext _context;

    public OrderDetailRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // Ejercicio 3: Obtener productos de una orden específica
    public async Task<List<object>> GetProductsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => new
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync<object>();
    }

    // Ejercicio 4: Obtener cantidad total de productos por orden
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }

    // Ejercicio 10: Obtener todos los pedidos y sus detalles
    public async Task<List<object>> GetAllOrderDetailsAsync()
    {
        return await _context.Orderdetails
            .Select(od => new
            {
                OrderId = od.OrderId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync<object>();
    }
}
