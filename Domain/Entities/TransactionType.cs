using Domain.Base;

namespace Domain.Entities;

public class TransactionType : BaseModel
{
    public string Name { get; set; } = null!;
    public List<Transaction> Transactions { get; set; } = [];
}
