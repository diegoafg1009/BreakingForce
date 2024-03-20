namespace Application.Contracts.Variation.DTOs;

public class CreateVariation
{
    public Guid? Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Weight { get; set; }
    public int Stock { get; set; }
    public Guid FlavorId { get; set; }
}