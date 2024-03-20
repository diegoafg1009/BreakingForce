namespace Domain.Entities;

public class OrderDetail
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid ProductVariationId { get; set; }
    public ProductVariation ProductVariation { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal Amount { get; set; }
}
