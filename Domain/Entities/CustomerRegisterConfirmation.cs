using Domain.Base;

namespace Domain.Entities;

public class CustomerRegisterConfirmation : BaseModel
{
    public string Token { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}