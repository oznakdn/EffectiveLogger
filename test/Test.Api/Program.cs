using Test.Api.Middleware;
using System.Reflection;
using Gleeman.EffectiveLogger.SQLite.Configurations;
using Gleeman.EffectiveLogger.File.Configurations;
using Gleeman.EffectiveLogger.MSSqlServer.Configurations;
using Gleeman.EffectiveLogger.PostgreSQL.Configurations;
using Gleeman.EffectiveLogger.MySQL.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoggingMiddleware>();

//builder.Logging.ClearProviders();



builder.Services.
AddFileLog(option =>
{
    option.FilePath = "C:\\Users\\USER\\Desktop\\EffectiveMapper\\test\\Test.Api\\FileLog";
    option.FileName = "Test";
}).AddSQLiteLog(options =>
{
    options.ConnectionString = "Data Source = C:\\Users\\USER\\Desktop\\EffectiveMapper\\test\\Test.Api\\DataLog\\Log.db";
    options.Assembly = Assembly.GetExecutingAssembly();
});


//.AddMySqlLog(options =>
//{
//    options.ConnectionString = "Server=localhost;Port=3306;Database=LogDb;user=root;password=123456;";
//    options.Assembly = Assembly.GetExecutingAssembly();
//});


//.AddPostgreSqlLog(options =>
//{
//    options.ConnectionString = "Server=localhost;Port=5432;Database=LogDb;UserId=postgre;Password=postgre123;";
//    options.Assembly = Assembly.GetExecutingAssembly();
//});



//.AddSQLiteLog(options =>
//{
//    options.ConnectionString = "Data Source = C:\\Users\\USER\\Desktop\\EffectiveMapper\\test\\Test.Api\\DataLog\\Log.db";
//    options.Assembly = Assembly.GetExecutingAssembly();
//}).AddMySqlLog(options =>
//{
//    options.ConnectionString = "Server=localhost;Port=3306;Database=LogDb;user=root;password=123456;";
//    options.Assembly = Assembly.GetExecutingAssembly();
//}).AddPostgreSqlLog(options =>
//{
//    options.ConnectionString = "Server=localhost;Port=5432;Database=LogDb;User Id=postgres;Password=postgres123;";
//    options.Assembly = Assembly.GetExecutingAssembly();
//});



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
