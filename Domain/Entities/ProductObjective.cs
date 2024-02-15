using Domain.Base;

namespace Domain.Entities;

public class ProductObjective : BaseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
