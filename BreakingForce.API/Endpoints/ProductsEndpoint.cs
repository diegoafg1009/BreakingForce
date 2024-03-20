using Application.Contracts.Product.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class ProductsEndpoint
{
    public static RouteGroupBuilder MapProducts(this RouteGroupBuilder group)
    {
        group.MapPost("/create", CreateProduct).DisableAntiforgery().Accepts<CreateProductDto>("multipart/form-data");
        group.MapGet("/get-all", FilterProducts);
        return group;
    }

    private static string CreateProduct(HttpRequest request, [FromServices] IProductService productService, IMapper mapper)
    {
        var form = request.Form;
        Console.WriteLine(form["variations"]);
        var createdProduct = mapper.Map<CreateProductDto>(request.Form);
        return "Product";
    }

    private static async Task<Ok<List<GetProductSimpleDto>>> FilterProducts([AsParameters] ProductFilterDto filterDto,
        [FromServices] IProductService productService)
    {
        var products = await productService.FilterProducts(filterDto);
        return TypedResults.Ok(products);
    }
}