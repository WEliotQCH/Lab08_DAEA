using LAB8CALIFICADO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB8CALIFICADO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Ejercicio 3: Obtener productos de una orden específica
    /// </summary>
    [HttpGet("{orderId}/products")]
    public async Task<IActionResult> GetProductsByOrderId(int orderId)
    {
        var products = await _orderService.GetProductsByOrderIdAsync(orderId);
        return Ok(products);
    }

    /// <summary>
    /// Ejercicio 4: Obtener cantidad total de productos por orden
    /// </summary>
    [HttpGet("{orderId}/total-quantity")]
    public async Task<IActionResult> GetTotalQuantityByOrderId(int orderId)
    {
        var total = await _orderService.GetTotalQuantityByOrderIdAsync(orderId);
        return Ok(total);
    }

    /// <summary>
    /// Ejercicio 6: Obtener pedidos después de una fecha específica
    /// </summary>
    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _orderService.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }

    /// <summary>
    /// Ejercicio 10: Obtener todos los pedidos y sus detalles
    /// </summary>
    [HttpGet("all-details")]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        var details = await _orderService.GetAllOrderDetailsAsync();
        return Ok(details);
    }
}
