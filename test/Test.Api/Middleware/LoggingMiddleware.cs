using Gleeman.EffectiveLogger.Logger;

namespace Test.Api.Middleware;

public class LoggingMiddleware : IMiddleware
{
    private readonly IEffectiveLog<LoggingMiddleware> _log;

    public LoggingMiddleware(IEffectiveLog<LoggingMiddleware> log)
    {
        _log = log;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _log.Debug($"{DateTime.Now} - {context.Request.Method}");
        try
        {
            _log.Information($"{DateTime.Now} - {context.Request.Method} {context.Response.StatusCode}");
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            _log.Fail($"{DateTime.Now} - {context.Request.Method} - {ex.Message.ToString()}");
        }
    }
}
