namespace LAB8CALIFICADO.Repositories.Interfaces;

public interface IOrderDetailRepository
{
    Task<List<object>> GetProductsByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<List<object>> GetAllOrderDetailsAsync();
}
