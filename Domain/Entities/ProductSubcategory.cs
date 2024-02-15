using Domain.Base;

namespace Domain.Entities;

public class ProductSubcategory : BaseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
