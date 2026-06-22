namespace LAB8CALIFICADO.DTOs;

public class ClientDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class ClientWithOrdersDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public int OrderCount { get; set; }
}


