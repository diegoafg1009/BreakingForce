using Domain.Base;

namespace Domain.Entities;

public class District : BaseModel
{
    public string Name { get; set; } = null!;
    public Guid ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
    public List<Address> Addresses { get; set; } = [];
}
