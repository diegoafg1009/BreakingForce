using Domain.Base;

namespace Domain.Entities;

public class Identification : BaseModel
{
    public string Number { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Guid IdentificationTypeId { get; set; }
    public IdentificationType IdentificationType { get; set; } = null!;
}