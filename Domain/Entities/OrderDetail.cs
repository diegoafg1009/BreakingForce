namespace Domain.Entities;

public class OrderDetail
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal Amount { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
