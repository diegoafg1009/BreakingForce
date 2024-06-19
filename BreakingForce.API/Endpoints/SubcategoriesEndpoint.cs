using Application.Contracts.Subcategory.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class SubcategoriesEndpoint
{
    public static RouteGroupBuilder MapSubcategories(this RouteGroupBuilder group)
    {
        group.MapGet("/get-all", GetAllSubcategories);
        group.MapGet("/get-all-active", GetAllActiveSubcategories);
        return group;
    }

    private static async Task<Ok<List<GetSubcategory>>> GetAllSubcategories([FromServices] ISubcategoryService subcategoryService)
    {
        var subcategories = await subcategoryService.GetAllSubcategories();
        return TypedResults.Ok(subcategories);
    }

    private static async Task<Ok<List<GetSubcategory>>> GetAllActiveSubcategories([FromServices] ISubcategoryService subcategoryService)
    {
        var subcategories = await subcategoryService.GetAllWithAnyProduct();
        return TypedResults.Ok(subcategories);
    }
}