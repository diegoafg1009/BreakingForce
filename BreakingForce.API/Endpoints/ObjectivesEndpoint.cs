using Application.Contracts.Objective.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class ObjectivesEndpoint
{
    public static RouteGroupBuilder MapObjectives(this RouteGroupBuilder group)
    {
        group.MapGet("/get-all", GetAllObjectives);
        group.MapGet("/get-all-active", GetAllActiveObjectives);
        return group;
    }

    private static async Task<Ok<List<GetObjective>>> GetAllObjectives([FromServices] IObjectiveService objectiveService)
    {
        var objectives = await objectiveService.GetAllObjectives();
        return TypedResults.Ok(objectives);
    }

    private static async Task<Ok<List<GetObjective>>> GetAllActiveObjectives([FromServices] IObjectiveService objectiveService)
    {
        var objectives = await objectiveService.GetAllWithAnyProduct();
        return TypedResults.Ok(objectives);
    }
}