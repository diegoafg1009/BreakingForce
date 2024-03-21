using Application.Contracts.Product.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
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

    private static async Task<Created<GetProductDto>> CreateProduct(HttpRequest request, [FromServices] IProductService productService, IMapper mapper)
    {
        var createdProduct = mapper.Map<CreateProductDto>(request.Form)!;
        var product = await productService.CreateProduct(createdProduct, Guid.Empty);

        return TypedResults.Created((string?)null, product);
    }

    private static async Task<Ok<List<GetProductSimpleDto>>> FilterProducts([AsParameters] ProductFilterDto filterDto,
        [FromServices] IProductService productService)
    {
        var products = await productService.FilterProducts(filterDto);
        return TypedResults.Ok(products);
    }
}