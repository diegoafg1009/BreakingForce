using Domain.Base;

namespace Domain.Entities;

public class ProductBrand : BaseModel
{
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
