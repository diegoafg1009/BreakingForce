using Application.Contracts.Flavor.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class FlavorsEndpoint
{
    public static RouteGroupBuilder MapFlavors(this RouteGroupBuilder group)
    {
        group.MapGet("/get-all", GetAllFlavors);
        return group;
    }

    private static async Task<Ok<List<GetFlavor>>> GetAllFlavors([FromServices] IFlavorService flavorService)
    {
        var flavors = await flavorService.GetAllFlavors();
        return TypedResults.Ok(flavors);
    }

}