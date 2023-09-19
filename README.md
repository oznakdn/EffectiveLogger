# Gleeman Effective Logger

`dotnet` CLI
```
> dotnet add package Gleeman.EffectiveLogger --version 2.0.2
> dotnet add package Gleeman.EffectiveLogger.SQLite --version 2.0.1
> dotnet add package Gleeman.EffectiveLogger.MSSqlServer --version 2.0.2
> dotnet add package Gleeman.EffectiveLogger.PostgreSQL --version 2.0.1
> dotnet add package Gleeman.EffectiveLogger.MySQL --version 2.0.1

```
### How To Use?

#### appsettings.json
```csharp
{
  "LogOptions": {
    "WriteToFile": true, // true or false
    "WriteToDatabase": true, // true or false
    // if WriteToFile is true, you should to write here 'FilePath' and 'FileName'
    "FilePath": "", 
    "FileName": "",
    "DatabaseOptions": {
      // if WriteToDatabase is true, you should to write here 'connection string'
      "SQLiteConnectionString": "",
      "MSSqlServerConectionString": "",
      "PostgreSqlConnectionString": "",
      "MySqlConnectionString": ""
    }
  }
}
```

#### program.cs
##### Logging to SQLite
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration)
                .AddSQLiteLog(builder.Configuration, assembly: Assembly.GetExecutingAssembly());
```
##### Logging to MSSqlServer
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration)
                .AddMSSqlServerLog(builder.Configuration, assembly: Assembly.GetExecutingAssembly());
```

##### Logging to PostgreSql
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration)
                .AddPostgreSqlLog(builder.Configuration, assembly: Assembly.GetExecutingAssembly());
```


##### If you won't use a database for logging
```csharp
builder.Logging.ClearProviders();
builder.Services.AddEffectiveLogger(builder.Configuration);
```

#### Middleware or Controller

##### Middleware
```csharp
public class LoggingMiddleware : IMiddleware
{
    private readonly IEffectiveLog<LoggingMiddleware> _log;

    public LoggingMiddleware(IEffectiveLog<LoggingMiddleware> log)
    {
        _log = log;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _log.Debug($"{context.Request.Method}");
        try
        {
            _log.Information($"{context.Request.Method} {context.Response.StatusCode}");
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            _log.Fail($"{context.Request.Method} - {ex.Message.ToString()}");
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
        private readonly IEffectiveLog<ValuesController> _log;

        public ValuesController(IEffectiveLog<ValuesController> log)
        {
            _log = log;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _log.Information("Information");
            _log.Debug("Debug");

            var values = new List<string>()
            {
                "Value1",
                "Value2",
                "Value3",
                "Value4",

            };
            _log.Fail("Fail");
            _log.Warning("Warning");

            return Ok(values);
        }
    }

```
