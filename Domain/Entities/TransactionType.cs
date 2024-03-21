using Domain.Base;

namespace Domain.Entities;

public class TransactionType : BaseModel
{
    public string Name { get; set; }
    public List<Transaction> Transactions { get; set; } = [];

    public TransactionType(Guid id,string name)
    {
        Id = id;
        Name = name;
    }
}
