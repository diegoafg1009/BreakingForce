using Domain.Base;

namespace Domain.Entities;

public class Order : BaseModel
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Note { get; set; }
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
    public Guid OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;
    public Guid? ShipmentId { get; set; }
    public Shipment? Shipment { get; set; }
    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
}
