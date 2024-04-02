using Application.Contracts.Variation.DTOs;
using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Product.DTOs;

public class UpdateProduct
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid SubcategoryId { get; set; }
    public Guid ObjectiveId { get; set; }
    public Guid BrandId { get; set; }
    public FormFileCollection Images { get; set; } = null!;
    public List<UpdateVariation> Variations { get; set; } = null!;
}