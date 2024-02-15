using Domain.Base;

namespace Domain.Entities;

public class Identification : BaseModel
{
    public string Number { get; set; } = null!;
    public Guid IdentificationTypeId { get; set; }
    public IdentificationType IdentificationType { get; set; } = null!;
    public List<CustomerIdentification> CustomerIdentifications { get; set; } = [];
}
