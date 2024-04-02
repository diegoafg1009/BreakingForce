using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Brand.DTOs;

public class CreateBrand()
{
    public string Name { get; set; } = null!;
    public FormFile Image { get; set; } = null!;
}