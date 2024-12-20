namespace Application.Contracts.Subcategory.DTOs;

public class GetSubcategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CategoryId { get; set; }
}