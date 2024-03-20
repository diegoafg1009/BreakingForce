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
        return group;
    }

    private static async Task<Ok<List<GetObjectiveDto>>> GetAllObjectives([FromServices] IObjectiveService objectiveService)
    {
        var objectives = await objectiveService.GetAllObjectives();
        return TypedResults.Ok(objectives);
    }
}