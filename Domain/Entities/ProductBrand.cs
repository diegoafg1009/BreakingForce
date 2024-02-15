namespace Domain.Entities;

public class ProductBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
