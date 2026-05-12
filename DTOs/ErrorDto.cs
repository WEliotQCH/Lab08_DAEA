namespace LAB8CALIFICADO.DTOs;

public class ErrorDto
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public string? Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
