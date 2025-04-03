using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly IHostEnvironment _env;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(IHostEnvironment env, ILogger<ExceptionMiddleware> logger)
    {
        _env = env;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment()
                ? new ErrorResponse(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace?.ToString() ?? string.Empty)
                : new ErrorResponse(context.Response.StatusCode.ToString(), "Internal Server Error", "An error occurred while processing your request.");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}

public sealed record ErrorResponse(string statusCode, string Message, string Details);
