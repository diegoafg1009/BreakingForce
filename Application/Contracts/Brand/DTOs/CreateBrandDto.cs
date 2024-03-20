using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Brand.DTOs;

public class CreateBrandDto()
{
    public string Name { get; set; } = null!;
    public FormFile Image { get; set; } = null!;
}