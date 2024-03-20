namespace Application.Contracts.Category.DTOs;

public class GetCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}