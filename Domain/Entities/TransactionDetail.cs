namespace Domain.Entities;

public class TransactionDetail
{
    public int AmountAffected { get; set; }
    public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; } = null!;
    public Guid InventoryId { get; set; }
    public ProductInventory Inventory { get; set; } = null!;
}
