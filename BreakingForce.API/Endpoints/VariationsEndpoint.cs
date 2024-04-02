using Application.Contracts.Variation.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class VariationsEndpoint
{
    public static RouteGroupBuilder MapVariations(this RouteGroupBuilder group)
    {
        group.MapGet("/{variationId}", GetVariation);
        return group;
    }

    private static async Task<Ok<GetVariation>> GetVariation([FromServices] IVariationService variationService, Guid variationId)
    {
        var variation = await variationService.GetVariation(variationId);
        return TypedResults.Ok(variation);
    }

}