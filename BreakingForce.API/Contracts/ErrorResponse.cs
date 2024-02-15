using System.Text.Json;

namespace BreakingForce.API.Contracts;

public class ErrorResponse(string message)
{
    public string? StatusCode { get; set; }
    public string Message { get; set; } = message;
    public IDictionary<string, string[]>? Errors { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
