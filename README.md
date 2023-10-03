# Gleeman Effective Logger


## Logging to SQLite
#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger --version 2.0.5
$ dotnet add package Gleeman.EffectiveLogger.SQLite --version 2.0.5
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.SQLite.Configurations;
```
```csharp
builder.Services.AddSQLiteLog(options =>
{
    options.ConnectionString = "Connection string is here";
    options.WriteToFile = true;
    options.WriteToConsole = true;
    options.FilePath = "File path is here";
    options.FileName = "File name is here";
    options.MigrationAssembly = Assembly.GetExecutingAssembly();
});
```

<hr>

## Logging to MSSQLServer
#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger --version 2.0.5
$ dotnet add package Gleeman.EffectiveLogger.MSSqlServer --version 2.0.5
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.MSSqlServer.Configurations;
```
```csharp
builder.Services.AddMSSqlServerLog(options =>
{
    options.ConnectionString = "Connection string is here";
    options.WriteToFile = true;
    options.WriteToConsole = true;
    options.FilePath = "File path is here";
    options.FileName = "File name is here";
    options.MigrationAssembly = Assembly.GetExecutingAssembly();
});
```
<hr>

## Logging to MySQL
#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger --version 2.0.5
$ dotnet add package Gleeman.EffectiveLogger.MySQL --version 2.0.5
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.MySQL.Configurations;
```
```csharp
builder.Services.AddMySqlLog(options =>
{
    options.ConnectionString = "Connection string is here";
    options.WriteToFile = true;
    options.WriteToConsole = true;
    options.FilePath = "File path is here";
    options.FileName = "File name is here";
    options.MigrationAssembly = Assembly.GetExecutingAssembly();
});
```
<hr>

## Logging to PostgreSQL
#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger --version 2.0.5
$ dotnet add package Gleeman.EffectiveLogger.PostgreSQL --version 2.0.5
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.PostgreSQL.Configurations;
```
```csharp
builder.Services.AddPostgreSqlLog(options =>
{
    options.ConnectionString = "Connection string is here";
    options.WriteToFile = true;
    options.WriteToConsole = true;
    options.FilePath = "File path is here";
    options.FileName = "File name is here";
    options.MigrationAssembly = Assembly.GetExecutingAssembly();
});
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



