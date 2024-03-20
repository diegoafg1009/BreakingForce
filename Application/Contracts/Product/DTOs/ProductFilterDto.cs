using Application.Contracts.FilterItem.DTOs;

namespace Application.Contracts.Product.DTOs;

public class ProductFilterDto() : FilterDto
{
    public Guid? BrandId { get; set; }
    public Guid? SubcategoryId { get; set; }
    public Guid? ObjectiveId { get; set; }
}