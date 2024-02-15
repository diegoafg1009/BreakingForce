using Domain.Base;

namespace Domain.Entities;

public class Order : BaseModel
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderDetail> OrderDetails { get; set; } = [];
    public Guid OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public string? Note { get; set; }
    public Guid ShippingMethodId { get; set; }
    public ShippingMethod ShippingMethod { get; set; } = null!;
    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
}
