using LAB8CALIFICADO.Data;
using LAB8CALIFICADO.Models;
using LAB8CALIFICADO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB8CALIFICADO.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly LinqExampleContext _context;

    public OrderRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // Ejercicio 6: Obtener pedidos después de una fecha específica
    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .ToListAsync();
    }
}
