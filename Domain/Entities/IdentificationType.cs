using Domain.Base;

namespace Domain.Entities;

public class IdentificationType : BaseModel
{
    public string Name { get; set; } = null!;
    public List<Identification> Identifications { get; set; } = [];
}
