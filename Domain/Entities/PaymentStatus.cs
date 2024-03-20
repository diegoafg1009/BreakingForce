using Domain.Base;

namespace Domain.Entities;

public class PaymentStatus(Guid id, string name) : Status(id, name)
{
    public List<Payment> Payments { get; set; } = [];
}