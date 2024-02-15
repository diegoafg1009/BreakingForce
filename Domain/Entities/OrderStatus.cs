using Domain.Base;

namespace Domain.Entities;

public class OrderStatus : Status
{
    protected OrderStatus(Guid id, string name) : base(id, name)
    {
    }
}
