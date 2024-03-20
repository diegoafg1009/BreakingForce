using Domain.Base;

namespace Domain.Entities;

public class ProductInventory(int quantity) : BaseModel
{
    public int Quantity { get; set; } = quantity;
    public Guid ProductVariationId { get; set; }
    public ProductVariation ProductVariation { get; set; } = null!;
    public List<TransactionDetail> TransactionDetails { get; set; } = [];
}
