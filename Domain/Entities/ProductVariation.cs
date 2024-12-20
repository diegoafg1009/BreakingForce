using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities;

public class ProductVariation : BaseModel
{
    public decimal UnitPrice { get; set; }
    public decimal Weight { get; set; }
    public string MeasureUnit { get; set; } = null!;
    public bool IsActive { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid? FlavorId { get; set; }
    public ProductFlavor? Flavor { get; set; }
    public Guid ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = null!;
    public List<OrderDetail> OrderDetails { get; set; } = [];
}