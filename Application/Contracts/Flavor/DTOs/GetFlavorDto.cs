namespace Application.Contracts.Flavor.DTOs;

public class GetFlavorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
}