using Domain.Base;

namespace Domain.Entities;

public class Customer : BaseModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdentificationId { get; set; }
    public Identification Identification { get; set; } = null!;
    public Guid? EnterpriseDataId { get; set; }
    public EnterpriseData? EnterpriseData { get; set; }
    public Guid? AddressId { get; set; }
    public Address? Address { get; set; }
    public List<Order> Orders { get; set; } = [];
}
