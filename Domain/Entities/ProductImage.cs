using Domain.Base;

namespace Domain.Entities;

public class ProductImage(string url) : BaseModel
{
    public string Url { get; set; } = url;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
