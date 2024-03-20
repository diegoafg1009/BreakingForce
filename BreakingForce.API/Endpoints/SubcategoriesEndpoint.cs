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
        return group;
    }

    private static async Task<Ok<List<GetSubcategoryDto>>> GetAllSubcategories([FromServices] ISubcategoryService subcategoryService)
    {
        var subcategories = await subcategoryService.GetAllSubcategories();
        return TypedResults.Ok(subcategories);
    }
}