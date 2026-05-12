using System.Net;
using System.Text.Json;
using LAB8CALIFICADO.DTOs;

namespace LAB8CALIFICADO.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var errorResponse = new ErrorDto
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = "An error occurred while processing your request",
            Details = exception.Message
        };

        // Personalizar respuesta según tipo de excepción
        switch (exception)
        {
            case ArgumentNullException:
            case ArgumentException:
                errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = "Invalid request parameters";
                break;

            case KeyNotFoundException:
                errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse.Message = "Resource not found";
                break;

            case UnauthorizedAccessException:
                errorResponse.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorResponse.Message = "Unauthorized access";
                break;

            case InvalidOperationException:
                errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = "Invalid operation";
                break;
        }

        context.Response.StatusCode = errorResponse.StatusCode;

        var jsonResponse = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }
}
