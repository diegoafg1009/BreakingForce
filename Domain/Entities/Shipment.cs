using Domain.Base;

namespace Domain.Entities;

public class Shipment : BaseModel
{
    public string Address { get; set; } = null!;
    public string? Reference { get; set; }
    public Guid DistrictId { get; set; }
    public District District { get; set; } = null!;
    public Guid ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}