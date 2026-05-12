namespace LAB8CALIFICADO.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class OrderProductDto
{
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}

public class OrderTotalQuantityDto
{
    public int OrderId { get; set; }
    public int TotalQuantity { get; set; }
}

public class OrderDetailDto
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}
