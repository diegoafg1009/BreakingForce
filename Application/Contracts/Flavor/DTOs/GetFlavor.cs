namespace Application.Contracts.Flavor.DTOs;

public class GetFlavor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
}