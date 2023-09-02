using Gleeman.EffectiveLogger.Interfaces;

namespace Test.Api.Middleware;

public class LoggingMiddleware : IMiddleware
{
    private readonly IEffectiveLogger<LoggingMiddleware> _effectiveLogger;

    public LoggingMiddleware(IEffectiveLogger<LoggingMiddleware> effectiveLogger)
    {
        _effectiveLogger = effectiveLogger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _effectiveLogger.Debug($"{context.Request.Method} - Request");
        try
        {
            _effectiveLogger.Information($"{context.Request.Method} {context.Response.StatusCode} - Response");
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            _effectiveLogger.Fail($"{context.Request.Method} - {ex.Message.ToString()} - Request failed...");
        }
    }
}
