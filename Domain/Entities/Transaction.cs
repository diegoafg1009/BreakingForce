using Domain.Base;

namespace Domain.Entities;

public class Transaction (DateTime date, Guid transactionTypeId) : BaseModel
{
    public DateTime Date { get; set; } = date;
    public Guid TransactionTypeId { get; set; } = transactionTypeId;
    public TransactionType TransactionType { get; set; } = null!;
    public List<TransactionDetail> TransactionDetails { get; set; } = [];
    public Guid? OrderId { get; set; }
    public Order? Order { get; set; }
    public Guid? UserId { get; set; }
}
