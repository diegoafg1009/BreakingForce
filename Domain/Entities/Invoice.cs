using Domain.Base;

namespace Domain.Entities;

public class Invoice : BaseModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Guid IdentificationTypeId { get; set; }
    public string IdentificationNumber { get; set; } = null!;
    public string? Ruc { get; set; }
    public string? BusinessName { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Total { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
