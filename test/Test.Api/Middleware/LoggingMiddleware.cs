﻿using Gleeman.EffectiveLogger.Logger;

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
        try
        {
            _log.Information($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Debug($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Warning($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");

            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            
            _log.Fail($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode} - {ex.Message}");
        }
    }
}
