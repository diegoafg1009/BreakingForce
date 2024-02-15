using Domain.Base;

namespace Domain.Entities;

public class Transaction : BaseModel
{
    public DateTime Date { get; set; }
    public Guid TransactionTypeId { get; set; }
    public TransactionType TransactionType { get; set; } = null!;
    public Guid? OrderId { get; set; }
    public Order? Order { get; set; }
    public Guid? UserId { get; set; }
}
