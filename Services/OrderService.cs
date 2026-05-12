using LAB8CALIFICADO.DTOs;
using LAB8CALIFICADO.Repositories.Interfaces;
using LAB8CALIFICADO.Services.Interfaces;

namespace LAB8CALIFICADO.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<List<OrderDto>> GetOrdersAfterDateAsync(DateTime date)
    {
        var orders = await _orderRepository.GetOrdersAfterDateAsync(date);
        return orders.Select(o => new OrderDto
        {
            OrderId = o.OrderId,
            ClientId = o.ClientId,
            OrderDate = o.OrderDate
        }).ToList();
    }

    public async Task<List<OrderProductDto>> GetProductsByOrderIdAsync(int orderId)
    {
        var products = await _orderDetailRepository.GetProductsByOrderIdAsync(orderId);
        return products.Select(p =>
        {
            var props = p.GetType().GetProperties();
            return new OrderProductDto
            {
                ProductName = (string)props.First(prop => prop.Name == "ProductName").GetValue(p)!,
                Quantity = (int)props.First(prop => prop.Name == "Quantity").GetValue(p)!
            };
        }).ToList();
    }

    public async Task<OrderTotalQuantityDto> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        var total = await _orderDetailRepository.GetTotalQuantityByOrderIdAsync(orderId);
        return new OrderTotalQuantityDto
        {
            OrderId = orderId,
            TotalQuantity = total
        };
    }

    public async Task<List<OrderDetailDto>> GetAllOrderDetailsAsync()
    {
        var details = await _orderDetailRepository.GetAllOrderDetailsAsync();
        return details.Select(d =>
        {
            var props = d.GetType().GetProperties();
            return new OrderDetailDto
            {
                OrderId = (int)props.First(p => p.Name == "OrderId").GetValue(d)!,
                ProductName = (string)props.First(p => p.Name == "ProductName").GetValue(d)!,
                Quantity = (int)props.First(p => p.Name == "Quantity").GetValue(d)!
            };
        }).ToList();
    }
}
