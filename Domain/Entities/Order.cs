using Domain.Base;

namespace Domain.Entities;

public class Order : BaseModel
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Note { get; set; }
    public string ReferencePhone { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderDetail> OrderDetails { get; set; } = [];
    public Guid OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public Guid DeliveryMethodId { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; } = null!;
    public Guid? ShipmentId { get; set; }
    public Shipment? Shipment { get; set; }
    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
}
