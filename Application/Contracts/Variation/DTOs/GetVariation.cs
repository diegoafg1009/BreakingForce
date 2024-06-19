namespace Application.Contracts.Variation.DTOs;

public class GetVariation
{
    public Guid Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Weight { get; set; }
    public string MeasureUnit { get; set; } = null!;
    public int Stock { get; set; }
    public bool IsActive { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid ProductId { get; set; }
    public string? FlavorName { get; set; }
    public string? FlavorColor { get; set; }
    public string Image { get; set; } = null!;
}