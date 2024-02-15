using Domain.Base;

namespace Domain.Entities;

public class District : BaseModel
{
    public string Name { get; set; } = null!;
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
}
