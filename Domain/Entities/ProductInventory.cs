using Domain.Base;

namespace Domain.Entities;

public class ProductInventory : BaseModel
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public List<TransactionDetail> TransactionDetails { get; set; } = [];
}
