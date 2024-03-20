using Domain.Base;

namespace Domain.Entities;

public class OrderStatus(Guid id, string name) : Status(id, name)
{
    public List<Order> Orders { get; set; } = [];
}
