using Domain.Base;

namespace Domain.Entities;

public class Payment : BaseModel
{
    public string ExternalId { get; set; } = null!;
    public DateTime Date { get; set; }
    public Guid PaymentStatusId { get; set; }
    public PaymentStatus PaymentStatus { get; set; } = null!;
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}