using Domain.Base;

namespace Domain.Entities;

public class PaymentMethod : BaseModel
{
    public string Name { get; set; } = null!;
}
