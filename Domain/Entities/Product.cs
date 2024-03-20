using Domain.Base;

namespace Domain.Entities;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public Guid SubcategoryId { get; set; }
    public ProductSubcategory Subcategory { get; set; } = null!;
    public Guid ObjectiveId { get; set; }
    public ProductObjective Objective { get; set; } = null!;
    public Guid BrandId { get; set; }
    public ProductBrand Brand { get; set; } = null!;
    public List<ProductImage> Images { get; set; } = [];
    public List<ProductVariation> Variations { get; set; } = [];
}
