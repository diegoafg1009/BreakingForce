namespace Application.Contracts.Product.DTOs;

public class GetProductSimpleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal LowerPrice { get; set; }
    public decimal HigherPrice { get; set; }
    public int Stock { get; set; }
    public string Subcategory { get; set; } = null!;
    public string Objective { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Image { get; set; } = null!;
}