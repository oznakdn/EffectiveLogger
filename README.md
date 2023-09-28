# Gleeman Effective Logger

`dotnet` CLI
```
> dotnet add package Gleeman.EffectiveLogger.SQLite --version 2.0.1
> dotnet add package Gleeman.EffectiveLogger.MSSqlServer --version 2.0.2
> dotnet add package Gleeman.EffectiveLogger.PostgreSQL --version 2.0.1
> dotnet add package Gleeman.EffectiveLogger.MySQL --version 2.0.1

```
# How To Use?

### appsettings.json
```csharp

// If WriteToFile and WriteToDatabase are false, only logging is done to the console.
// If WriteToFile and WriteToDatabase are true, logging are done to the Console,File and Database
{
  "LogOptions": {
    "WriteToFile": true,
    "WriteToDatabase": true,
    "FilePath": "", 
    "FileName": "",
    "DatabaseOptions": {
      "SQLiteConnectionString": "",
      "MSSqlServerConectionString": "",
      "PostgreSqlConnectionString": "",
      "MySqlConnectionString": ""
    }
  }
}
```
<hr>

### Program.cs
#### Logging to SQLite
```csharp
builder.Services.AddSQLiteLog(builder.Configuration,assembly:Assembly.GetExecutingAssembly());
```
#### Logging to MSSQLServer
```csharp
builder.Services.AddMSSqlServerLog(builder.Configuration,assembly:Assembly.GetExecutingAssembly());
```
#### Logging to MySQL
```csharp
builder.Services.AddMySqlLog(builder.Configuration,assembly:Assembly.GetExecutingAssembly());
```
#### Logging to PostgreSQL
```csharp
builder.Services.AddPostgreSqlLog(builder.Configuration,assembly:Assembly.GetExecutingAssembly());
```
<hr>


### Middleware
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
        try
        {
            _log.Information($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Debug($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Fail($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Warning($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");

            await next.Invoke(context);
        }
        catch (Exception ex)
        {
           _log.Fail($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode} - {ex.Message}");
        }
    }
}
```
### Console Screen
![Console](https://github.com/oznakdn/EffectiveLogger/assets/79724084/3bf0e989-643e-4652-825d-8634d19b75c5)

### File Screen
![File](https://github.com/oznakdn/EffectiveLogger/assets/79724084/186199f3-f36e-4683-8911-823dd70f1d9f)

### Database Screen
![Database](https://github.com/oznakdn/EffectiveLogger/assets/79724084/f7235067-10a9-462f-9b24-d44db017b653)



