namespace Domain.Base;

public class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
