using Domain.Base;

namespace Domain.Entities;

public class ShippingMethod : BaseModel
{
    public string Name { get; set; } = null!;
}
