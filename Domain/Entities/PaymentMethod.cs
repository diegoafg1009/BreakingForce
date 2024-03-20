using Domain.Base;

namespace Domain.Entities;

public class PaymentMethod : BaseModel
{
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public List<Payment> Payments { get; set; } = [];
}
