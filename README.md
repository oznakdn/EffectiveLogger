# Gleeman Effective Logger

[![Nuget version](https://img.shields.io/nuget/v/Gleeman.EffectiveLogger.svg?logo=nuget)](https://www.nuget.org/packages/Gleeman.EffectiveLogger/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Gleeman.EffectiveLogger?logo=nuget)](https://www.nuget.org/packages/Gleeman.EffectiveLogger/)
![Build & Test Main](https://github.com/Blazored/LocalStorage/workflows/Build%20&%20Test%20Main/badge.svg)

### How To Use?

#### appsettings.json
```csharp
{
  "LogOption": {
    "WriteToConsole": true , // true or false
    "WriteToFile": true , // true or false
    "WriteToDatabase": true , // true or false
    "FilePath": "", // your file path here
    "FileName": "", // file name here
    "ConnectionString": "" // database connection string here
  }
}

```

#### program.cs
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration, ProviderType.SQLite, nameof(Program)); // Using SQLite
builder.Services.AddEffectiveLogger(builder.Configuration, ProviderType.MsSQL, nameof(Program)); // Using MsSQL
builder.Services.AddEffectiveLogger(builder.Configuration, ProviderType.PostgreSQL, nameof(Program)); // Using PostgreSQL
builder.Services.AddEffectiveLogger(builder.Configuration, ProviderType.MySQL, nameof(Program)); // Using MySQL 

```
##### If you won't use a database for logging
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration, null, null);
```

#### Middleware or Controller

##### Middleware
```csharp
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
```

##### Controller
```csharp
 [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEffectiveLogger<ValuesController> _effectiveLogger;

        public ValuesController(IEffectiveLogger<ValuesController> effectiveLogger)
        {
            _effectiveLogger = effectiveLogger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _effectiveLogger.Information("Information");
            _effectiveLogger.Debug("Debug");

            var values = new List<string>()
            {
                "Value1",
                "Value2",
                "Value3",
                "Value4",

            };
            _effectiveLogger.Fail("Fail");
            _effectiveLogger.Warning("Warning");

            return Ok(values);
        }
    }

```
