using Domain.Base;

namespace Domain.Entities;

public class Invoice : BaseModel
{
    public string AssociatedDocument { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Amount { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
