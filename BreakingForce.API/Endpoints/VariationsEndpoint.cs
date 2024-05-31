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
        group.MapPost("/by-ids", GetVariationsById);
        return group;
    }

    private static async Task<Ok<GetVariation>> GetVariation([FromServices] IVariationService variationService, Guid variationId)
    {
        var variation = await variationService.GetVariation(variationId);
        return TypedResults.Ok(variation);
    }

    private static async Task<Ok<List<GetVariation>>> GetVariationsById([FromServices] IVariationService variationService, [FromBody]IEnumerable<Guid> ids)
    {
        var variations = await variationService.GetVariationsById(ids);
        return TypedResults.Ok(variations);
    }

}