using LAB8CALIFICADO.DTOs;

namespace LAB8CALIFICADO.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrdersAfterDateAsync(DateTime date);
    Task<List<OrderProductDto>> GetProductsByOrderIdAsync(int orderId);
    Task<OrderTotalQuantityDto> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<List<OrderDetailDto>> GetAllOrderDetailsAsync();
}
