namespace Domain.Base;

public class Status : BaseModel
{
    public string Name { get; set; }
    protected Status(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
