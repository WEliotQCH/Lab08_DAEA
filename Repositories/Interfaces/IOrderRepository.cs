using LAB8CALIFICADO.Models;

namespace LAB8CALIFICADO.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
}
