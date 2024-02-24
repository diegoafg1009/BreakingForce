using Domain.Base;

namespace Domain.Entities;

public class OrderStatus : Status
{
    public List<Order> Orders { get; set; } = [];
}
