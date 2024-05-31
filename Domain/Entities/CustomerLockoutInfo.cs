using Domain.Base;

namespace Domain.Entities;

public class CustomerLockoutInfo : BaseModel
{
    public int AccessFailedCount { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}