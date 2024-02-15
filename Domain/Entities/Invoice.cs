using Domain.Base;

namespace Domain.Entities;

public class Invoice : BaseModel
{
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalTax { get; set; }
    public decimal TotalAmountWithTax { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
