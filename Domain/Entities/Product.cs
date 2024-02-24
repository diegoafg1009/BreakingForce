using Domain.Base;

namespace Domain.Entities;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public Guid CategoryId { get; set; }
    public ProductSubcategory Category { get; set; } = null!;
    public Guid ObjectiveId { get; set; }
    public ProductObjective Objective { get; set; } = null!;
    public Guid BrandId { get; set; }
    public ProductBrand Brand { get; set; } = null!;
    public Guid InventoryId { get; set; }
    public ProductInventory Inventory { get; set; } = null!;
    public List<ProductImage> Images { get; set; } = [];
    public List<OrderDetail> OrderDetails { get; set; } = [];
}
