using Domain.Base;

namespace Domain.Entities;

public class Department : BaseModel
{
    public string Name { get; set; } = null!;
    public List<Province> Provinces { get; set; } = [];
}
