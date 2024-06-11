using Application.Services.Interfaces;
using Application.Utils;
using BreakingForce.API.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BreakingForce.API.Endpoints;

public static class ImagesEndpoint
{
    public static RouteGroupBuilder MapImages(this RouteGroupBuilder group)
    {
        group.MapGet("/{*path}", GetImage);
        return group;
    }

    //Download image
    private static async Task<IResult> GetImage([FromServices] IFileStorageService fileStorageService, string path)
    {
        var stream = new MemoryStream();
        await fileStorageService.GetFile(path, stream);
        stream.Position = 0;
        var extension = Path.GetExtension(path);
        var contentType = MimeMapping.GetMime(extension);
        return Results.File(stream, contentType);
    }
}