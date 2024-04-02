namespace Application.Contracts.Variation.DTOs;

public class UpdateVariation
{
    public Guid? Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Weight { get; set; }
    public bool IsActive { get; set; }
    public int Stock { get; set; }
    public Guid? FlavorId { get; set; }
}