using Application.Contracts.Product.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using BreakingForce.API.Utils;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class ProductsEndpoint
{
    public static RouteGroupBuilder MapProducts(this RouteGroupBuilder group)
    {
        group.MapGet("/{productId}", GetProduct);
        group.MapPost("/", CreateProduct).DisableAntiforgery().Accepts<CreateProduct>("multipart/form-data");
        group.MapPut("/{productId}", UpdateProduct).DisableAntiforgery().Accepts<UpdateProduct>("multipart/form-data");
        group.MapGet("/filter", FilterProducts);
        return group;
    }

    private static async Task<Ok<GetProduct>> GetProduct([FromServices] IProductService productService, Guid productId)
    {
        var product = await productService.GetProduct(productId);
        return TypedResults.Ok(product);
    }

    private static async Task<Created<GetProduct>> CreateProduct(HttpRequest request, [FromServices] IProductService productService, IMapper mapper)
    {
        var createdProduct = mapper.Map<CreateProduct>(request.Form)!;
        var product = await productService.CreateProduct(createdProduct, Guid.Empty);

        return TypedResults.Created((string?)null, product);
    }

    private static async Task<Ok<GetProduct>> UpdateProduct(HttpRequest request, [FromServices] IProductService productService, IMapper mapper, Guid productId)
    {
        var updatedProduct = mapper.Map<UpdateProduct>(request.Form);
        var product = await productService.UpdateProduct(updatedProduct, productId, Guid.Empty);

        return TypedResults.Ok(product);
    }

    private static async Task<Ok<List<GetProductSimpleDto>>> FilterProducts([AsParameters] ProductFilterDto filterDto,
        [FromServices] IProductService productService, HttpContext httpContext)
    {
        var (paginatedProducts, recordsPerPage) = await productService.FilterProducts(filterDto);
        httpContext.InsertPaginationParametersInHeader(recordsPerPage, paginatedProducts.Count);
        return TypedResults.Ok(paginatedProducts);
    }
}