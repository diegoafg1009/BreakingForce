using Domain.Base;

namespace Domain.Entities;

public class DeliveryMethod : BaseModel
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public List<Order> Orders { get; set; } = [];
}
