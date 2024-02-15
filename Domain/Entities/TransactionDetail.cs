namespace Domain.Entities;

public class TransactionDetail
{
    public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; } = null!;
    public Guid InventoryId { get; set; }
    public ProductInventory Inventory { get; set; } = null!;
    public int AmountAffected { get; set; }
}
