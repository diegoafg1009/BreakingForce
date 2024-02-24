using Domain.Base;

namespace Domain.Entities;

public class Address : BaseModel
{
    public string Description { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string? Reference { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid DistrictId { get; set; }
    public District District { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}