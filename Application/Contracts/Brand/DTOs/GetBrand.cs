namespace Application.Contracts.Brand.DTOs;

public class GetBrand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}