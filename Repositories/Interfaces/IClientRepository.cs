using LAB8CALIFICADO.Models;

namespace LAB8CALIFICADO.Repositories.Interfaces;

public interface IClientRepository
{
    Task<List<Client>> GetClientsByNameAsync(string name);
    Task<object> GetClientWithMostOrdersAsync();
    Task<List<string>> GetClientsByProductIdAsync(int productId);
}
