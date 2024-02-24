using Domain.Base;

namespace Domain.Entities;

public class EnterpriseData : BaseModel
{
    public string BusinessName { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}
