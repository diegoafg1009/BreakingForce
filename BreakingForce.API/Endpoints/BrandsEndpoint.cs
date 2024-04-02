using Application.Contracts.Brand.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class BrandsEndpoint
{
    public static RouteGroupBuilder MapBrands(this RouteGroupBuilder group)
    {
        group.MapPost("/", CreateBrand).DisableAntiforgery().Accepts<CreateBrand>("multipart/form-data");
        group.MapGet("/get-all", GetAllBrands);
        return group;
    }

    private static async Task<Created<GetBrand>> CreateBrand( HttpRequest request, [FromServices] IBrandService brandService, [FromServices] IMapper mapper)
    {
        var createBrandDto = mapper.Map<CreateBrand>(request.Form)!;
        var brand = await brandService.CreateBrand(createBrandDto);
        return TypedResults.Created( (string?)null, brand);
    }

    private static async Task<Ok<List<GetBrand>>> GetAllBrands([FromServices] IBrandService brandService)
    {
        var brands = await brandService.GetAllBrands();
        return TypedResults.Ok(brands);
    }
}