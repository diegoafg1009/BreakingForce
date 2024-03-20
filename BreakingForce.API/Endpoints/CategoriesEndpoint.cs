using Application.Contracts.Category.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class CategoriesEndpoint
{
    public static RouteGroupBuilder MapCategories(this RouteGroupBuilder group)
    {
        group.MapGet("/get-all", GetAllCategories);
        return group;
    }

    private static async Task<Ok<List<GetCategoryDto>>> GetAllCategories([FromServices] ICategoryService categoryService)
    {
        var categories = await categoryService.GetAllCategories();
        return TypedResults.Ok(categories);
    }
}