using Domain.Base;

namespace Domain.Entities;

public class ProductImage(string url, int order) : BaseModel
{
    public string Url { get; set; } = url;
    public int Order { get; set; } = order;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
