# Gleeman Effective Logger


## SQLite
#### Install packages
`dotnet CLI`
```csharp
dotnet add package Gleeman.EffectiveLogger --version 2.0.6
```
```csharp
dotnet add package Gleeman.EffectiveLogger.SQLite --version 2.0.5
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

## MSSQLServer
#### Install packages
`dotnet CLI` 
```csharp
dotnet add package Gleeman.EffectiveLogger --version 2.0.6
```
```csharp
dotnet add package Gleeman.EffectiveLogger.MSSqlServer --version 2.0.5
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

## MySQL
#### Install packages
`dotnet CLI` 
```csharp
dotnet add package Gleeman.EffectiveLogger --version 2.0.6
```
```csharp
dotnet add package Gleeman.EffectiveLogger.MySQL --version 2.0.5
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

## PostgreSQL
#### Install packages
`dotnet CLI`
```csharp
dotnet add package Gleeman.EffectiveLogger --version 2.0.6
```
```csharp
dotnet add package Gleeman.EffectiveLogger.PostgreSQL --version 2.0.5
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



### USAGE
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
            _log.Information($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Debug($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            _log.Warning($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");

            await next.Invoke(context);
        }
        catch (Exception ex)
        {
           _log.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode} - {ex.Message}");
        }
    }
}
```
### Console Screen
![Console](https://github.com/oznakdn/EffectiveLogger/assets/79724084/083fcf05-eace-42b3-a78f-263f8df62245)

### File Screen
![File](https://github.com/oznakdn/EffectiveLogger/assets/79724084/86b40e19-3bf3-4bb2-bc17-bd82ecfadbec)

### Database Screen
![Database](https://github.com/oznakdn/EffectiveLogger/assets/79724084/83a72943-55d9-46f7-bce9-b4e28657d8dc)




