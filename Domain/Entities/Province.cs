using Domain.Base;

namespace Domain.Entities;

public class Province : BaseModel
{
    public string Name { get; set; } = null!;
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public List<District> Districts { get; set; } = [];
}
