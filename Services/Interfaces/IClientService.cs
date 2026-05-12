using LAB8CALIFICADO.DTOs;

namespace LAB8CALIFICADO.Services.Interfaces;

public interface IClientService
{
    Task<List<ClientDto>> GetClientsByNameAsync(string name);
    Task<ClientWithOrdersDto> GetClientWithMostOrdersAsync();
    Task<List<string>> GetClientsByProductIdAsync(int productId);
}
