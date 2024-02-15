using Domain.Base;

namespace Domain.Entities;

public class ProductCategory : BaseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public List<ProductSubcategory> Subcategories { get; set; } = [];
}
