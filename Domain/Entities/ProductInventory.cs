using Domain.Base;

namespace Domain.Entities;

public class ProductInventory(int quantity) : BaseModel
{
    public int Quantity { get; set; } = quantity;
    public ProductVariation ProductVariation { get; set; } = null!;
    public List<TransactionDetail> TransactionDetails { get; set; } = [];
}
