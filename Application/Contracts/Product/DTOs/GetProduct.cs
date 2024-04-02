using Application.Contracts.Variation.DTOs;

namespace Application.Contracts.Product.DTOs;

public class GetProduct
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal LowerPrice { get; set; }
    public decimal HigherPrice { get; set; }
    public int Stock { get; set; }
    public Guid SubcategoryId { get; set; }
    public string Subcategory { get; set; } = null!;
    public Guid ObjectiveId { get; set; }
    public string Objective { get; set; } = null!;
    public Guid BrandId { get; set; }
    public string Brand { get; set; } = null!;
    public List<string> Images { get; set; } = null!;
    public bool IsActive { get; set; }
    public List<GetVariationSimple> Variations { get; set; } = null!;
}