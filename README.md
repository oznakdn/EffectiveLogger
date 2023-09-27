# Gleeman Effective Logger

`dotnet` CLI
```
> dotnet add package Gleeman.EffectiveLogger.File --version 2.0.0
> dotnet add package Gleeman.EffectiveLogger.SQLite --version 2.0.2
> dotnet add package Gleeman.EffectiveLogger.MSSqlServer --version 2.0.3
> dotnet add package Gleeman.EffectiveLogger.PostgreSQL --version 2.0.2
> dotnet add package Gleeman.EffectiveLogger.MySQL --version 2.0.2

```
## How To Use?

#### program.cs

##### Logging to console and file log
```csharp
builder.Services.AddFileLog(option =>
{
    option.FilePath = "C:\\Users\\USER\\Desktop\\EffectiveMapper\\test\\Test.Api\\FileLog";
    option.FileName = "Test";
});
```
##### Logging to MSSqlServer
```csharp
builder.Services.AddMSSqlServerLog(options =>
{
    options.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LogDb;Integrated Security=True;Trust Server Certificate=False;";
    options.Assembly = Assembly.GetExecutingAssembly();
});
```

##### Logging to PostgreSql
```csharp
builder.Services.AddPostgreSqlLog(options =>
{
    options.ConnectionString = "Server=localhost;Port=5432;Database=LogDb;UserId=postgre;Password=postgre123;";
    options.Assembly = Assembly.GetExecutingAssembly();
});
```

##### Logging to MySql
```csharp
builder.Services.AddMySqlLog(options =>
{
   options.ConnectionString = "Server=localhost;Port=3306;Database=LogDb;user=root;password=123456;";
   options.Assembly = Assembly.GetExecutingAssembly();
});
```
##### Logging to Console, File and Database
```csharp
builder.Services.AddFileLog(option =>
{
    option.FilePath = "C:\\Users\\USER\\Desktop\\EffectiveMapper\\test\\Test.Api\\FileLog";
    option.FileName = "Test";
}).AddMSSqlServerLog(options =>
{
    options.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LogDb;Integrated Security=True;Trust Server Certificate=False;";
    options.Assembly = Assembly.GetExecutingAssembly();
});
```


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



