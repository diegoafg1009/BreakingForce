using Domain.Base;

namespace Domain.Entities;

public class Coupon : BaseModel
{
    public string Code { get; set; } = null!;
    public decimal Discount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsOneUseOnly { get; set; }
    public List<Order> Orders { get; set; } = [];
}
