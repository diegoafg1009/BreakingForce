using System.Net;
using Application.Exceptions;
using BreakingForce.API.Contracts;

namespace BreakingForce.API.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var errorResponse = new ErrorResponse(e.Message);

            switch (e)
            {
                case AppException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ValidationException ve:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Errors = ve.Errors;
                    break;
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenException:
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case ConflictException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(e, e.Message);
            errorResponse.StatusCode = response.StatusCode.ToString();
            await response.WriteAsync(errorResponse.ToString());
        }
    }
}
