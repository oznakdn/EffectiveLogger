using Test.Api.Middleware;
using System.Reflection;
using Gleeman.EffectiveLogger.SQLite.Configurations;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoggingMiddleware>();


//Server=localhost;Port=5432;Database=LogDb;User Id=postgres;Password=postgres123;

builder.Services.AddSQLiteLog(options =>
{
    options.ConnectionString = "Data Source = C:\\Users\\HP\\Desktop\\Ozan\\EffectiveLogger\\test\\Test.Api\\DataLog\\Log.db";
    options.WriteToFile = true;
    options.WriteToConsole = true;
    options.FilePath = "C:\\Users\\HP\\Desktop\\Ozan\\EffectiveLogger\\test\\Test.Api\\FileLog";
    options.FileName = "Test";
    options.MigrationAssembly = Assembly.GetExecutingAssembly();
});



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
