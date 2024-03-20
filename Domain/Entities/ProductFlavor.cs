using Domain.Base;

namespace Domain.Entities;

public class ProductFlavor : BaseModel
{
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public List<ProductVariation> ProductsVariations { get; set; } = [];
}