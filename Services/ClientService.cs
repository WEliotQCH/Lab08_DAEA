using LAB8CALIFICADO.DTOs;
using LAB8CALIFICADO.Repositories.Interfaces;
using LAB8CALIFICADO.Services.Interfaces;

namespace LAB8CALIFICADO.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientDto>> GetClientsByNameAsync(string name)
    {
        var clients = await _clientRepository.GetClientsByNameAsync(name);
        return clients.Select(c => new ClientDto
        {
            ClientId = c.ClientId,
            Name = c.Name,
            Email = c.Email
        }).ToList();
    }

    public async Task<ClientWithOrdersDto> GetClientWithMostOrdersAsync()
    {
        var result = await _clientRepository.GetClientWithMostOrdersAsync();

        // Convertir el objeto anónimo a ClientWithOrdersDto
        var props = result.GetType().GetProperties();
        return new ClientWithOrdersDto
        {
            ClientId = (int)props.First(p => p.Name == "ClientId").GetValue(result)!,
            ClientName = (string)props.First(p => p.Name == "ClientName").GetValue(result)!,
            OrderCount = (int)props.First(p => p.Name == "OrderCount").GetValue(result)!
        };
    }

    public async Task<List<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _clientRepository.GetClientsByProductIdAsync(productId);
    }
}
