using Domain.Base;

namespace Domain.Entities;

public class ProductImage : BaseModel
{
    public string ImageUrl { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
