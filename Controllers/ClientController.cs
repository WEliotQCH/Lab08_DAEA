using LAB8CALIFICADO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB8CALIFICADO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    /// <summary>
    /// Ejercicio 1: Obtener clientes por nombreS
    /// </summary>
    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetClientsByName(string name)
    {
        var clients = await _clientService.GetClientsByNameAsync(name);
        return Ok(clients);
    }

    /// <summary>
    /// Ejercicio 9: Obtener el cliente con mayor número de pedidos
    /// </summary>
    [HttpGet("most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var client = await _clientService.GetClientWithMostOrdersAsync();
        return Ok(client);
    }

    /// <summary>
    /// Ejercicio 12: Obtener clientes que compraron un producto específico
    /// </summary>
    [HttpGet("by-product/{productId}")]
    public async Task<IActionResult> GetClientsByProductId(int productId)
    {
        var clients = await _clientService.GetClientsByProductIdAsync(productId);
        return Ok(clients);
    }
}
