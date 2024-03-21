namespace Application.Contracts.Variation.DTOs;

public class GetVariationDto
{
    public Guid Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Weight { get; set; }
    public int Stock { get; set; }
    public bool IsActive { get; set; }
    public string? FlavorName { get; set; }
    public string? FlavorColor { get; set; }
}