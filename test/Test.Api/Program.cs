using Gleeman.EffectiveLogger.Configuration;
using Test.Api.Middleware;
using System.Reflection;
using Gleeman.EffectiveLogger.SQLite.Configurations;
using Gleeman.EffectiveLogger.MSSqlServer.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoggingMiddleware>();

builder.Logging.ClearProviders();

builder.Services.AddEffectiveLogger(builder.Configuration)
                .AddSQLiteLog(builder.Configuration, assembly: Assembly.GetExecutingAssembly())
                .AddMSSqlServerLog(builder.Configuration, assembly: Assembly.GetExecutingAssembly());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
