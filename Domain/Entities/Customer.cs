using Domain.Base;

namespace Domain.Entities;

public class Customer : BaseModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    public List<CustomerIdentification> CustomerIdentifications { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
}
