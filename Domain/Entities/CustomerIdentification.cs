namespace Domain.Entities;

public class CustomerIdentification
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Guid IdentificationId { get; set; }
    public Identification Identification { get; set; } = null!;
}
