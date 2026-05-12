using LAB8CALIFICADO.Data;
using LAB8CALIFICADO.Models;
using LAB8CALIFICADO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB8CALIFICADO.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly LinqExampleContext _context;

    public ClientRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // Ejercicio 1: Obtener clientes por nombre
    public async Task<List<Client>> GetClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }

    // Ejercicio 9: Obtener el cliente con mayor número de pedidos
    public async Task<object> GetClientWithMostOrdersAsync()
    {
        var result = await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                ClientName = g.First().Client.Name,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .FirstOrDefaultAsync();

        return result ?? new { ClientId = 0, ClientName = "No hay clientes", OrderCount = 0 };
    }

    // Ejercicio 12: Obtener clientes que compraron un producto específico
    public async Task<List<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
}
